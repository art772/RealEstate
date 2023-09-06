using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Application.Users.Commands.EditUserData;
using RealEstate.Application.Users.Queries.GetUserDetails;
using RealEstate.Application.Users.Queries.GetUserEstates;
using RealEstate.Application.Users.Queries.GetUsers;
using RealEstate.Domain.Entities;
using System.Security.Claims;

namespace RealEstate.Controllers.User
{
    [Route("api/users/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IPhotoService _photoService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEstateDbContext _context;
        public UserController(IPhotoService photoService, UserManager<ApplicationUser> userManager, IEstateDbContext context)
        {
            _photoService = photoService;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GestUsers()
        {
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            return Ok(await Mediator.Send(new GetUserDetailsQuery() { UserId = id }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserEstates(int id)
        {
            return Ok(await Mediator.Send(new GetUserEstatesQuery() { UserId = id }));
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> EditUserData(EditUserDataCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoto(IFormFile file, CancellationToken cancellationToken)
        {
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userManager.FindByNameAsync(userName);

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null ) return BadRequest(result.Error.Message);

            var photo = new UserPhoto
            {
                Url = result.SecureUri.AbsoluteUri,
                PublicId = result.PublicId,
                ApplicationUserId = user.Id
            };

            _context.UserPhotos.Add(photo);
            await _context.SaveChangesAsync(cancellationToken);

            user.UserPhotoId = photo.Id;
            await _userManager.UpdateAsync(user);

            return Ok();
        }

        [HttpDelete]
        [Route("{photoId}")]
        public async Task<IActionResult> DeletePhoto(int photoId)
        {
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userManager.Users
              .Include(x => x.UserPhoto)
              .FirstOrDefaultAsync(x => x.UserName == userName);

            var photo = user.UserPhoto;

            if (photo == null || photo.Id != photoId) return NotFound();

            if (photo.PublicId != null)
            {
                var result = await _photoService.DeletePhotoAsync(photo.PublicId);
                if ( result.Error != null ) return BadRequest(result.Error.Message);
            }

            user.UserPhoto = null;
            user.UserPhotoId = null;
            await _userManager.UpdateAsync(user);
            
            return Ok("Zdjęcie zostało usunięte.");
        }
    }
}
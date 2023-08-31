using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public UserController(IPhotoService photoService, UserManager<ApplicationUser> userManager)
        {
            _photoService = photoService;
            _userManager = userManager;
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
        public async Task<IActionResult> AddPhoto(IFormFile file)
        {
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userManager.FindByNameAsync(userName);

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null ) return BadRequest(result.Error.Message);

            var photo = new UserPhoto
            {
                Url = result.SecureUri.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (user.UserPhotos.Count == null) photo.IsMain = true;
            
            user.UserPhotos.Add(photo);

            await _userManager.UpdateAsync(user);

            return Ok();
        }
    }
}
namespace RealEstate.Application.Common.Exceptions
{
    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException() : base(String.Format("User does not exist"))
        {
        }
    }
}
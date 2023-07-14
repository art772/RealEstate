namespace RealEstate.Application.Common.Exceptions
{
    public class InvalidEstateIdException : Exception
    {
        public InvalidEstateIdException(int id) : base(String.Format($"Estate with Id: {id} doesn't exist"))
        {
        }
    }
}
namespace RealEstate.Application.Common.Exceptions
{
    public class NotDeletedEstateException : Exception
    {
        public NotDeletedEstateException(int id) : base(String.Format($"Estate with this Id: {id} is not deleted"))
        {
        }
    }
}
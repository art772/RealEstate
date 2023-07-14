namespace RealEstate.Application.Common.Exceptions
{
    public class NotYourEstateException : Exception
    {
        public NotYourEstateException() : base(String.Format("This Estate does not belong to You"))
        {
        }
    }
}
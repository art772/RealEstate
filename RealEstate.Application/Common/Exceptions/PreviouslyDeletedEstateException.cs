namespace RealEstate.Application.Common.Exceptions
{
    public class PreviouslyDeletedEstateException : Exception
    {
        public PreviouslyDeletedEstateException() : base(String.Format("This estate has been removed"))
        {
        }
    }
}
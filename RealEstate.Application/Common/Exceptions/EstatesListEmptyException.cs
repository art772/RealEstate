namespace RealEstate.Application.Common.Exceptions
{
    public class EstatesListEmptyException : Exception
    {
        public EstatesListEmptyException() : base(String.Format("Estates list is empty"))
        {
        }
    }
}
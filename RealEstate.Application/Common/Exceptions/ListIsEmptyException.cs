namespace RealEstate.Application.Common.Exceptions
{
    public class ListIsEmptyException : Exception
    {
        public ListIsEmptyException() : base(String.Format("List is empty"))
        {
        }
    }
}
namespace RealEstate.Application.Common.Exceptions
{
    public class CategoryDoesNotExistException : Exception
    {
        public CategoryDoesNotExistException() : base(String.Format("Category does not exist"))
        {
        }
    }
}
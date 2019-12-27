namespace Books.BL.Interfaces.Validation
{
    public interface IValidator
    {
        bool IsValid(string value, out string errorMessage);
    }
}

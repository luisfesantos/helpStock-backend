namespace HelpStockApp.Domain.Validation
{
    public class DomainExeceptionValidation : Exception
    {
        public DomainExeceptionValidation(string error) : base(error)
        {
        }

        public static void When(bool hasError, string error) 
        {
            if (hasError)
            {
                throw new DomainExeceptionValidation(error);
            }
        }
    }
}

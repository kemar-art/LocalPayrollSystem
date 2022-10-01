namespace PayrollSystem.Services.Contracts
{
    public interface IIncomTaxService
    {
        decimal IncomeTaxContibution(decimal totalAmount);
    }
}

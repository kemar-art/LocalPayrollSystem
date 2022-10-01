namespace PayrollSystem.Services.Contracts
{
    public interface ITaxService
    {
        decimal TaxAmount(decimal totalAmount);
    }
}

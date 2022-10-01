namespace PayrollSystem.Services.Contracts
{
    public interface INationalInsuranceSchemeTaxService
    {
        decimal NISTaxContibution(decimal totalAmount);
    }
}

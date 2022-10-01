namespace PayrollSystem.Services.Contracts
{
    public interface INationalInsuranceSchemeService
    {
        decimal NISTaxContibution(decimal totalAmount);
    }
}

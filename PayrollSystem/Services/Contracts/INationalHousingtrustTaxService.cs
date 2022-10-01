namespace PayrollSystem.Services.Contracts
{
    public interface INationalHousingtrustTaxService
    {
        decimal NHTTaxContribution(decimal totalAmount);
    }
}

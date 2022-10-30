using AutoMapper;
using PayrollSystem.Data;
using PayrollSystem.Models.EmployeeViewModel.EmployeeIndexVM;
using PayrollSystem.Models.EmployeeViewModel;
using PayrollSystem.Models.PaymentRecardViewModel;

namespace PayrollSystem.AutoMapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //CreateMap<Employee, EmployeeIndexVM>().ReverseMap();
            CreateMap<PaymentRecord, PaymentDetailVM>().ReverseMap();
        }
    }
}

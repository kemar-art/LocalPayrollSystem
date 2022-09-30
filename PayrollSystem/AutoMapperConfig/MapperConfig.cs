using AutoMapper;
using PayrollSystem.Data;
using PayrollSystem.Models.EmployeeViewModel.EmployeeIndexVM;
using PayrollSystem.Models.EmployeeViewModel;

namespace PayrollSystem.AutoMapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //CreateMap<Employee, EmployeeIndexVM>().ReverseMap();
            //CreateMap<Employee, EmployeeCreateVM>().ReverseMap();
        }
    }
}

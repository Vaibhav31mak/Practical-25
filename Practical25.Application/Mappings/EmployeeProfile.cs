
using Microsoft.Extensions.Options;
using System.ComponentModel;

namespace Practical25.Application.Mappings
{
    public sealed class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeResponse>();

            CreateMap<CreateEmployeeCommand, Employee>()
                .ForMember(destination => destination.JoiningDate, 
                options => options.MapFrom(_ => DateTime.UtcNow))
                .ForMember(destination => destination.Status,
                options => options.MapFrom(_ => true));

            CreateMap<UpdateEmployeeCommand, Employee>();
        }
    }
}

using AutoMapper;
using WorkforceHubAPI.Entities.Models;
using WorkforceHubAPI.Shared.DataTransferObjects;

namespace WorkforceHubAPI.WebAPI;

/// <summary>
/// Defines mapping configurations for AutoMapper to facilitate object-to-object mapping.
/// This profile ensures seamless transformation of entity objects into Data Transfer Objects (DTO)
/// and vice versa.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class and defines the mapping
    /// rules for AutoMapper.
    /// </summary>
    public MappingProfile()
    {
        // Configures the mapping between the Company entity and CompanyDto.
        // The FullAddress property in CompanyDto is gotten by concatenating the Address
        // and Country properties from the Company entity.
        CreateMap<Company, CompanyDto>()
            .ForMember(
                company => company.FullAddress,
                options => options.MapFrom(company => string.Join(", ", company.Address, company.Country))
            );

        // Configures the mapping between the Employee entity and EmployeeDto.
        CreateMap<Employee, EmployeeDto>();

        // Configures the mapping between the CompanyForCreationDto and Company entity.
        CreateMap<CompanyForCreationDto, Company>();

        // Configures the mapping between EmployeeForCreationDto and Employee entity.
        CreateMap<EmployeeForCreationDto, Employee>();

        // Configures the mapping between EmployeeForUpdateDto and Employee entity.
        CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

        // Configures the mapping between CompanyForUpdateDto and Company entity.
        CreateMap<CompanyForUpdateDto, Company>();
    }
}
using AutoMapper;
using WorkforceHubAPI.Contracts;
using WorkforceHubAPI.Service.Contracts;

namespace WorkforceHubAPI.Service;

/// <summary>
/// Service class responsible for implementing business logic operations related to the Employee entity.
/// Implements the <see cref="IEmployeeService"/> interface.
/// </summary>
internal sealed class EmployeeService : IEmployeeService
{
    // Repository manager for accessing data repositories
    private readonly IRepositoryManager _repository;

    // Logger for logging messages and errors.
    private readonly ILoggerManager _logger;

    // AutoMapper IMapper to perform object-to-object mapping.
    private readonly IMapper _mapper;

    public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
}

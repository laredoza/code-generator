// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using CodeGenerator.Infrastructure.Core.SharedKernel.FullContexts;
using Microsoft.Extensions.Logging;
using System;


namespace CodeGenerator.CodeGenerator.Api.V1.Services.FullContext
{
	public class CustomerService : ICustomerService
	{
		readonly ICustomerRepository _repository;
		readonly ILogger<CustomerService> _logger;

		public CustomerService(
			ICustomerRepository repository,
			ILogger<CustomerService> logger
		)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
    		}
	}
}


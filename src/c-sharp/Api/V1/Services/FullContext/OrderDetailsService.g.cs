// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using CodeGenerator.Infrastructure.Core.SharedKernel.FullContexts;
using Microsoft.Extensions.Logging;
using System;


namespace CodeGenerator.CodeGenerator.Api.V1.Services.FullContext
{
	public class OrderDetailsService : IOrderDetailsService
	{
		readonly IOrderDetailsRepository _repository;
		readonly ILogger<OrderDetailsService> _logger;

		public OrderDetailsService(
			IOrderDetailsRepository repository,
			ILogger<OrderDetailsService> logger
		)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
    		}
	}
}


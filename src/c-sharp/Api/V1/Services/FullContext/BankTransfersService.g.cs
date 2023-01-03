// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using CodeGenerator.Infrastructure.Core.SharedKernel.FullContexts;
using Microsoft.Extensions.Logging;
using System;


namespace CodeGenerator.CodeGenerator.Api.V1.Services.FullContext
{
	public class BankTransfersService : IBankTransfersService
	{
		readonly IBankTransfersRepository _repository;
		readonly ILogger<BankTransfersService> _logger;

		public BankTransfersService(
			IBankTransfersRepository repository,
			ILogger<BankTransfersService> logger
		)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
    		}
	}
}


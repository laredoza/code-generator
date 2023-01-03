// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using CodeGenerator.Infrastructure.Core.SharedKernel.FullContexts;
using Microsoft.Extensions.Logging;
using System;


namespace CodeGenerator.CodeGenerator.Api.V1.Services.FullContext
{
	public class BankAccountService : IBankAccountService
	{
		readonly IBankAccountRepository _repository;
		readonly ILogger<BankAccountService> _logger;

		public BankAccountService(
			IBankAccountRepository repository,
			ILogger<BankAccountService> logger
		)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
    		}
	}
}


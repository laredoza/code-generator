// *******************************************************************
//	GENERATED CODE. DOT NOT MODIFY MANUALLY AS CHANGES CAN BE LOST!!!
//	USE A PARTIAL CLASS INSTEAD
// *******************************************************************
using CodeGenerator.Infrastructure.Core.SharedKernel.FullContexts;
using Microsoft.Extensions.Logging;
using System;


namespace CodeGenerator.CodeGenerator.Api.V1.Services.FullContext
{
	public class CountryService : ICountryService
	{
		readonly ICountryRepository _repository;
		readonly ILogger<CountryService> _logger;

		public CountryService(
			ICountryRepository repository,
			ILogger<CountryService> logger
		)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
    		}
	}
}


// using System;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using CodeGenerator.Api.V1.Services;

// namespace CodeGenerator.Api.V1.Controllers
// {
// 	[ApiController]
// 	[Route("api/v{version:apiVersion}/[controller]")]
// 	[Produces("application/json")]
// 	public class TestController : BaseController
// 	{
// 		#region Fields
// 		readonly ILogger<TestController> _logger;
// 		private readonly ITestService _testService;
// 		#endregion

// 		#region Constructors

// 		public TestController(
// 		    ITestService testService,
// 		    ILogger<TestController> logger
// 		)
// 		{
// 			_logger = logger ?? throw new ArgumentNullException(nameof(logger));

// 			this._testService = testService ??
// 						      throw new ArgumentNullException(nameof(testService));
// 		}

// 		#endregion

// 		#region Public Methods

// 		// /// <response code="202">Task successfully queued.</response>
// 		// /// <response code="400">The provided model is incorrect.</response>
// 		// /// <response code="401">Unauthorized.</response>
// 		// /// <response code="404">Not Found.</response>
// 		// /// <response code="500">A server error occurred.</response>
// 		// /// <response code="502">A server error occurred. (Dependency failed.)</response>
// 		// [HttpPost("AddUser")]
// 		// [ProducesResponseType(StatusCodes.Status202Accepted)]
// 		// [ProducesResponseType(StatusCodes.Status400BadRequest)]
// 		// [ProducesResponseType(StatusCodes.Status401Unauthorized)]
// 		// [ProducesResponseType(StatusCodes.Status404NotFound)]
// 		// [ProducesResponseType(StatusCodes.Status500InternalServerError)]
// 		// [ProducesResponseType(StatusCodes.Status502BadGateway)]
// 		// [Authorize(Policy = "CanRead")]
// 		// public async Task<ActionResult> AddUser([FromBody] List<SocialMigrationMessage> messages)
// 		// {
// 		// 	return Accepted();
// 		// }

// 		#endregion

// 		#region Private Methods
// 		#endregion
// 	}
// }
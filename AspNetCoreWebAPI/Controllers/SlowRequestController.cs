using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreWebAPI.Helpers;
using System.Threading;

namespace AspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SlowRequestController : Controller
    {
        private readonly ILogger _logger;

        public SlowRequestController(ILogger<SlowRequestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/slowtest")]
        public async Task<string> Get(CancellationToken ct = default(CancellationToken))
        {
            //_logger.LogInformation("Starting to do Slow Work");
            FlatFileLogger.Log("Starting to do slow work");         //KD: Created this simpel logger as I couldn't figure out how to write to the console with the b uilt in ILogger service

            //KD: mocking slow async action e.g. call external api, build a report
            await Task.Delay(10_000,ct);

            var message = "Finished slow delay of 10 seconds";            

            //_logger.LogInformation(message);
            FlatFileLogger.Log(message);

            return message;
        }
    }
}
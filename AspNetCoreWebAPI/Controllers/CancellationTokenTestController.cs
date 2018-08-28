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
    /// <summary>
    ///     This controller created to test cancellation taokens used in both async and non cancellable (synchronous) methods
    ///     Most of the async methods have an overload that accepts cancellation token as an input parameter
    ///     ASP.NET will automatically bind it to the HttpContext.RequestAborted token using the "Cancellation Token Model Binder"
    ///     
    ///     When you cancel an async operation a "TaskCancelledException" is thrown
    ///     When you cancel a non async operation a "OperationCancelledException" is thrown
    ///     You have to handle that exception accordiongly in a catch block or using "Exception Filters"
    /// </summary>
    public class CancellationTokenTestController : Controller
    {
        private readonly ILogger _logger;

        public CancellationTokenTestController(ILogger<CancellationTokenTestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/slowtest")]
        public async Task<string> Get(CancellationToken ct)
        {
            //_logger.LogInformation("Starting to do Slow Work");
            FlatFileLogger.Log("Starting to do slow work");         //KD: Created this simpel logger as I couldn't figure out how to write 
                                                                    //to the console with the built in ILogger service
            string message = "";
            try
            {
                //KD: mocking slow async action e.g. call external api, build a report
                await Task.Delay(10_000, ct);
                message = "Finished slow delay of 10 seconds";

                //_logger.LogInformation(message);
                FlatFileLogger.Log(message);
            }
            catch(TaskCanceledException ex)
            {
                FlatFileLogger.Log("Framework Code :" + ex.Message);
            }
            return message;
        }

        [HttpGet("/buildreport")]
        public string BuildSlowReport(CancellationToken ct)
        {
            FlatFileLogger.Log(Environment.NewLine);
            FlatFileLogger.Log("Building the report started");
            string message=""; 
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    //KD: Mocking slow non cancellable work/operation
                    Thread.Sleep(1000);
                }
                message = "Finished Building the slow report";
                FlatFileLogger.Log(message);
            }
            catch(OperationCanceledException ex)
            {
                FlatFileLogger.Log("Developer Code : Building Report Cancelled");
                FlatFileLogger.Log("Framework Code : "+ex.Message);
            }
            return message;
        }
    }
}
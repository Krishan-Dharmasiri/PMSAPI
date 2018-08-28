using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPI.DataAccess.Services;
using AspNetCoreWebAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class InvestorsController : Controller
    {
        private readonly IInvestorService _investorService;
        public InvestorsController(IInvestorService investorService)
        {
            _investorService = investorService;
        }

        [HttpGet]
        public IEnumerable<InvestorDTO> Get()
        {
            return _investorService.Get();
        }
    }
}
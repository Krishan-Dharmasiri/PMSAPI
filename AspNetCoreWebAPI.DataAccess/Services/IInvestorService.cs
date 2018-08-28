using AspNetCoreWebAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreWebAPI.DataAccess.Services
{
    public interface IInvestorService
    {
        IEnumerable<InvestorDTO> Get();
    }
}

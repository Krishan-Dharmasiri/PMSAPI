using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreWebAPI.Models.DTOs;

namespace AspNetCoreWebAPI.DataAccess.Services
{
    public class InvestorService : IInvestorService
    {
        public IEnumerable<InvestorDTO> Get()
        {
            //TO DO : use the instance of the repository to get the data from the DB
            var inv = new List<InvestorDTO>() {
                new InvestorDTO(){FirstName="Kris",LastName="Dharmasiri",Email="kris@gmail.com",Region="Sri Lanka"},
                new InvestorDTO(){FirstName="Alaina",LastName="Gilbert",Email="alaina@gmail.com",Region="Australia"}
            };
            return inv;
        }
    }
}

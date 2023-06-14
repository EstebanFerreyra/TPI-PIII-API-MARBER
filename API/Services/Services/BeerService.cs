using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BeerService
    {
        private readonly Marber_BBDDContext _dbContext;

        public BeerService(Marber_BBDDContext context)
        {
            _dbContext = context;
        }

        public List<Beer> GetListBeer()
        {
            var list = _dbContext.Beer.ToList();
            return list;
        }
    }
}

using Betting.Contexts;
using Betting.Models;
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Betting.Services
{
    public class SportServices : ISportServices
    {
        private readonly DataBaseContext _dbContext;
        public SportServices(DataBaseContext dbContext)
        {
           _dbContext = dbContext;
        }

   
        public void BulkDelete()
        {
            throw new NotImplementedException();
        }

        public void BulkInsert(List<SportT> sport)
        {
            _dbContext.BulkInsert(sport, b => b.IncludeGraph = true);

        }

        public void BulkInsert()
        {
            throw new NotImplementedException();
        }

        public void BulkUpdate()
        {
            throw new NotImplementedException();
        }
    }
}

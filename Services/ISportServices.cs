using Betting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.Services
{
    public interface ISportServices
    {
        void BulkInsert(List<SportT> sport);
        void BulkUpdate();
        //void BulkSaveChanges();
        void BulkDelete();
    }
}

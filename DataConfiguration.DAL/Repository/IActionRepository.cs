using System;
using System.Collections.Generic;
using System.Text;

namespace DataConfiguration.DAL.Repository
{
    public interface IActionRepository
    {
        void ExecuteSp(string connectionString, string name, params object[] inputParams);
    }
}

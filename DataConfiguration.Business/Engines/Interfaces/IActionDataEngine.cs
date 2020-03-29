using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataConfiguration.Business.Engines.Interfaces
{
    public interface IActionDataEngine
    {
        void ExecuteAction(string actionName);
    }
}

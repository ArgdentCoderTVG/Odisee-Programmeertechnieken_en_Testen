using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrisdrankAutomaat
{
    public interface IAction
    {
        void DoAction(VendingMachine v);
        public string? Message { get; }
        public IAction NextAction { get; }
    }
}

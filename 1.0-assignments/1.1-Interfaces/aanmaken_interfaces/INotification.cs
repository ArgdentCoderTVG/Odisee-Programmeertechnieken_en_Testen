using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aanmaken_interfaces
{
    public interface INotification
    {
        string Logo { get; }
        string Titel { get; }
        string Beschrijving { get; }
        void Klik();
    }
}

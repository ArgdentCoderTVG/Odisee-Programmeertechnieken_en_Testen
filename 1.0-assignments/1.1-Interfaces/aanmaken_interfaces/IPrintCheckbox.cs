using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aanmaken_interfaces
{
    internal interface IPrintCheckbox
    {
        void Select();
        void Deselect();
        string Geselecteerd { get; set; }
    }
}

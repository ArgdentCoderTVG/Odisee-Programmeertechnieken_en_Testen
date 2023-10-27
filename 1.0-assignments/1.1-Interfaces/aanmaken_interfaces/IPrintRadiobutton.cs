using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aanmaken_interfaces
{
    internal interface IPrintRadiobutton
    {
        void Select();
        void Deselect();
        bool Geselecteerd { get; set; }
    }
}

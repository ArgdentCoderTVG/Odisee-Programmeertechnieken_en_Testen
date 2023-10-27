using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrisdrankAutomaat
{
    public class Drink
    {
        double _price;
        string _name;

        public Drink(string name, double price)
        {
            Price = price;
            Name = name;
        }

        public double Price { get => _price; private set => _price = value; }
        public string Name { get => _name; private set => _name = value; }
    }
}

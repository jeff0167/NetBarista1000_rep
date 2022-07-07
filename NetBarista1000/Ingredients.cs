using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBarista1000.Interfaces;

namespace NetBarista1000
{
    public abstract class Ingredients : BaristaItems
    {

        public string Name { get; set; }

        public Ingredients()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

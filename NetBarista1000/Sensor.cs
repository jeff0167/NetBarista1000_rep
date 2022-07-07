using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarista1000
{
    public class Sensor
    {
        public BaristaItems ItemToObserver { get; }

        public bool IsEmpty;

        public Sensor(BaristaItems itemToObserver)
        {
            ItemToObserver = itemToObserver;
            IsEmpty = false;
        }
    }
}

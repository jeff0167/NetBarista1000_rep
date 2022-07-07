using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetBarista1000.INetBarista;

namespace NetBarista1000
{
    public class NB1000 : NetBarista, INetBarista 
    {
        public NB1000(bool supportBeverage, bool ethernet, List<Sensor> sensors = null) : base(supportBeverage, ethernet, sensors)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarista1000.Interfaces
{
    public interface IDecorator
    {
        public String Description();

        public void Decorate(IDecorator component);
    }
}

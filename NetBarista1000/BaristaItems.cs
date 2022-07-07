using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBarista1000.Interfaces;

namespace NetBarista1000
{
    public abstract class BaristaItems : IDecorator
    {
        IDecorator decorator;

        public int PrepTime;

        public void Decorate(IDecorator component)
        {
            decorator = component;
        }

        public string Description()
        {
            return ToString();
        }

        public override string ToString()
        {
            string s = "";

            if (decorator != null)
            {
                try
                {
                    s = decorator.Description();
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
            }
            return " " + this.GetType().Name + s;
        }
    }
}

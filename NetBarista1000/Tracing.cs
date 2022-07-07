using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarista1000
{
    public class Tracing
    {
        public TraceSource ts;
        private static Tracing _Instance;

        public static Tracing Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Tracing();
                }
                return _Instance;
            }
        }
        public void Setup()
        {
            ts = new TraceSource("NB");
            ts.Switch = new SourceSwitch("Item log", "All");
            Console.WriteLine("Doing console log");
            TraceListener consoleLog = new ConsoleTraceListener();
            ts.Listeners.Add(consoleLog);
        }
    }
}

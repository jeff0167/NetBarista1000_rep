using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using NetBarista1000.ConcreteItems;

namespace NetBarista1000
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tracing.Instance.Setup();
            Tracing trace = Tracing.Instance;
            trace.ts.TraceEvent(TraceEventType.Information, 333, "Event log created");
              

            INetBarista nB1000 = new NB1000(true, true);
            nB1000.TurnOn();


            var d = new HotWater();

            var milk = new Milk();
            var water = new Water();

            milk.Decorate(new Water());

            d.Decorate(milk);

            Console.WriteLine(d.Description());


            nB1000.TakeOrder(new Order(new List<BaristaItems>() { d }));

            Console.WriteLine(nB1000.GetCurrentOrder().Id);
            //nB1000.TurnOff();
            nB1000.TakeOrder(new Order(new List<BaristaItems>() { new Sugar() }));

            nB1000.ExecuteCurrentOrder();

            Console.WriteLine(nB1000.GetCurrentOrder().Id);
            Console.WriteLine(nB1000.MachineStatus());
        }
    }
}

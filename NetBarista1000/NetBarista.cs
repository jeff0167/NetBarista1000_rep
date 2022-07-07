using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static NetBarista1000.INetBarista;
using System.Diagnostics;
using NSubstitute;
using System.Timers;

namespace NetBarista1000
{
    public abstract class NetBarista : INetBarista
    {
        static int OrderId;

        List<Sensor> Sensors = new List<Sensor>()
            {
                new Sensor(new Coffe()), new Sensor(new Cocoa()), new Sensor(new Milk()), new Sensor(new Sugar()), new Sensor(new Water())
            };

        public Queue<Order> Orders;
        public Order CurrentOrder;

        bool SupportBeverages;
        bool Ethernet;

        OperationState MachineState;

        public NetBarista(bool supportBeverage, bool ethernet, List<Sensor> sensors = null)
        {
            SupportBeverages = supportBeverage;
            Ethernet = ethernet;
            if (sensors != null)
            {
                Sensors = new List<Sensor>();
                sensors.AddRange(sensors);
            }
        }

        public static int GetOrderId()
        {
            return OrderId++;
        }

        public OperationState MachineStatus() // simulate we get status from the machine
        {
            return MachineState;
        }

        public virtual void AcceptOrder(Order order)
        {
            Console.WriteLine("Order accepted");
            Orders.Enqueue(order);                    // should have a threaded program where another thread knows when it has an order and then acts on it
            Console.WriteLine("Order id: " + GetCurrentOrder().Id);
            //Prepare(order);
        }

        public void TurnOn()
        {
            Orders = new Queue<Order>();
            MachineState = OperationState.On;
        }

        public void TakeOrder(Order order)
        {
            if (AbleToExecuteOrder(order))
            {
                AcceptOrder(order);
            }
            else
            {
                Console.WriteLine("Ordere rejected");
                RejectOrder();
            }
        }

        bool AbleToExecuteOrder(Order order)
        {
            if (MachineState > 0 && CheckSensorsForIngredients(order))
            {
                return true;
            }
            return false;
        }

        bool CheckSensorsForIngredients(Order order)
        {
            foreach (var item in order.GetAllItems())
            {
                foreach (var sen in Sensors)
                {
                    if (sen.IsEmpty && sen.ItemToObserver.GetType().Name.Contains(item.Description()))
                    {
                        Console.WriteLine(sen.ItemToObserver.GetType().Name);
                        Console.WriteLine(item.Description());

                        Console.WriteLine("Missing ingredient: " + sen.ItemToObserver.Description() + " is out of stock, please refill");
                        return false;
                    }
                }
            }
            return true;
        }


        void ExecuteOrder(Order order)
        {
            Prepare(order);
        }

        public void ExecuteCurrentOrder()
        {
            Prepare(GetCurrentOrder());
        }

        public void RejectOrder()
        {
            Console.WriteLine("The NB1000 is unavailable at this time as it is " + MachineState.ToString());
        }

        public void FetchNext()
        {
            if (Orders.TryPeek(out _) != false)
            {
                if (AbleToExecuteOrder(Orders.Peek()))
                {
                    ExecuteOrder(Orders.Peek());
                }
            }
        }

        public void Prepare(Order order)
        {
            MachineState = OperationState.ProccessingOrder;
            int prepareTime = order.PreperationTime() * 1000;
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, "Time to prepare: " + order.PreperationTime() + " sec");

            TimeIndicator(order.PreperationTime());

            Thread.Sleep(prepareTime);
            Tracing.Instance.ts.TraceEvent(TraceEventType.Information, 333, "item prepared " + order);
            Orders.Dequeue();
            MachineState = OperationState.On;
        }

        void TimeIndicator(int startTime)
        {
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += (sender, e) =>
            {
                Clock(startTime--);
            };
            timer.Interval = 1000;  // miliseconds
            timer.Start();
        }

        void Clock(int t)
        {
            Console.WriteLine("Sec: " + t);
        }


        public void TurnOff()
        {
            MachineState = OperationState.Off;
        }

        public Order GetCurrentOrder()
        {
            Order order = null;
            Orders.TryPeek(out order);
            return order;
        }
    }
}

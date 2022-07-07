using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarista1000
{
    public interface INetBarista
    {
        public enum OperationState
        {
            Off,
            On,         
            ProccessingOrder
        }

        public void TurnOn();
        public void TurnOff();

        public OperationState MachineStatus();

        public void TakeOrder(Order order);

        public Order GetCurrentOrder();

        public void FetchNext();

        public void ExecuteCurrentOrder();

        public void Prepare(Order order);
    }
}

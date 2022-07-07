using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarista1000
{
    public class Order
    {
        public int Id { get; set; } = -1;
        List<BaristaItems> Items { get; set; }

        public Order(List<BaristaItems> items)
        {
            Id = NetBarista.GetOrderId();
            Items = items;
        }

        public IReadOnlyList<BaristaItems> GetAllItems()
        {
            return Items;
        }

        public int PreperationTime()
        {
            int totalTime = 0;

            foreach (BaristaItems item in Items)
            {
                totalTime += item.PrepTime;
            }

            return totalTime;
        }

        public override string ToString()
        {
            string ingredientsDescription = "";

            foreach (var item in Items)
            {
                ingredientsDescription += item.ToString() + ", ";
            }

            for (int i = 0; i < 2; i++)
            {
                if(ingredientsDescription != "")
                {
                    ingredientsDescription = ingredientsDescription.Remove(ingredientsDescription.Length - 1);
                }
            }

            return $"Id {Id} " + ingredientsDescription;
        }
    }
}

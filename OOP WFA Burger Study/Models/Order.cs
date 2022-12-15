using OOP_WFA_Burger_Study.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WFA_Burger_Study.Models
{
    public class Order:BaseEntitiy
    {
        public Order()
        {
            ExtraSauces = new List<Extras>();
        }

        public Menu SelectedMenu { get; set; }
        public short Quantity { get; set; }
        public PizzaSizes Greatness { get; set; }
        public List<Extras> ExtraSauces { get; set; }


        public void CalculateSum()
        {
            Price = SelectedMenu.Price;

            switch(Greatness)
            {
                case PizzaSizes.Small:
                    Price -= 1;
                    break;

                case PizzaSizes.Gross:
                    Price += 2;
                    break;
            }
            foreach(Extras item in ExtraSauces)
            {
                Price += item.Price;
            }
            Price *= Quantity;
        }

        public override string ToString()
        {
            
            if(ExtraSauces.Count<1)
            {
                return $"{Name} {SelectedMenu} x {Quantity} {Greatness} SUM {Price}";
            }
            string extrasauces = null;

            foreach(Extras item in ExtraSauces)
            {
                extrasauces += $"{item.Name}";
            }

            extrasauces = extrasauces.TrimEnd(',');

            return $"{Name} {SelectedMenu} x {Quantity},{Greatness}, {extrasauces}, SUM{Price:C:2}";
        }

    }
}

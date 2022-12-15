using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_WFA_Burger_Study.Models
{
    public class Menu:BaseEntitiy
    {
        public string Info { get; set; }
        public override string ToString()
        {
            return $"{Name} >>>>{Price:C2}";

        }
    }
}

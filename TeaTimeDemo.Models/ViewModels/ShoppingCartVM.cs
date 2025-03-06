using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTimeDemo.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }//use enumerable besause it has a serious data in here
        // public double OrderTotal { get; set; }
        public OrderHeader OrderHeader { get; set; } // use object because it only use one object content
    }
}

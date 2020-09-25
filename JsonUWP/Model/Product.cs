using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUWP.Model
{
    class Product
    {

        public Product(int id, string name, string image, string description, int price)
        {
            this.id = id;
            this.name = name;
            this.image = image;
            this.description = description;
            this.price = price;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int price { get; set; }

        public string Price
        {
            get
            {
                var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
                return String.Format(info, "{0:c}", price);
                //String.Format("{0:C}", price);
            }
        }
    }
}

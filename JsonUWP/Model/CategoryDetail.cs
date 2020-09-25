using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUWP.Model
{
    class Data
    {
        public MenuItem category { get; set; }
        public List<Product> foods { get; set; }
    }

    class CategoryDetail
    {
        public string message { get; set; }
        public Data data { get; set; }
    }
}

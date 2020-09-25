using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUWP.Adapters
{
    class Adapter
    {
        private string baseURL = "https://foodgroup.herokuapp.com";

        public string TodaySpecial
        {
            get => String.Format(baseURL + "/api/today-special");
        }

        public string CategoryDetail(int id)
        {
            return String.Format(baseURL + "/api/category/" + id);
        }
    }
}

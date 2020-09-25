using JsonUWP.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JsonUWP.Model;
using Newtonsoft.Json;

namespace JsonUWP.Services
{
    class CategoryServices
    {
        private Adapter _adapter = new Adapter();

        public async Task<CategoryDetail> CategoryDetail(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_adapter.CategoryDetail(id));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CategoryDetail>(stringContent);
            }
            return null;
        }
    }
}

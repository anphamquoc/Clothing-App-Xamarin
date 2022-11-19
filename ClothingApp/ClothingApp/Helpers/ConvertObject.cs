using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothingApp.Helpers
{
    class ConvertObject<T>
    {
        public T ConvertObjectToData(object data)
        {
            T returnData = JsonConvert.DeserializeObject<T>(data.ToString());
            return returnData;
        }

        public List<T> ConvertObjectToListData(object data)
        {
            List<T> returnData = new List<T>();
            var result = ((IEnumerable<object>)data).Cast<object>().ToList();
            foreach (var item in result)
            {
                returnData.Add(JsonConvert.DeserializeObject<T>(item.ToString()));
            }

            return returnData;
        }
    }
}

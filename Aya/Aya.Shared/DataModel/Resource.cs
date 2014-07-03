using System;
using System.Collections.Generic;
using System.Text;
using Windows.Data.Json;

namespace Aya.DataModel
{
    public class Resource
    {
        public string Url { get; set; }
        public string Name { get; set; }

        public static Resource FromJsonObject(JsonObject jObject)
        {
            Resource r = new Resource();
            r.Url = jObject["url"].GetString();
            r.Name = jObject["name"].GetString();
            return r;
        }
    }
}

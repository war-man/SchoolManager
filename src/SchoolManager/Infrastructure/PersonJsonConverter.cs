using SchoolManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SchoolManager.Infrastructure
{
    class PersonJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            IList<Person> p = new List<Person>();

            while (reader.Read() && reader.TokenType == JsonToken.StartObject)
            {
                JObject obj = (JObject)serializer.Deserialize(reader);
                var person = new Person
                {
                    BirthDay = (DateTime)((JValue)obj["BirthDay"]).Value,
                    Classes = ((JValue)obj["Classes"]).Value.ToString().Split(new char[] { ',' }),
                    Fullname = ((JValue)obj["Fullname"]).Value.ToString(),
                    Id = ((JValue)obj["id"]).Value.ToString()
                };

                p.Add(person);
            }

            reader.Read();

            reader.Read();

            return p;
        }
    }
}

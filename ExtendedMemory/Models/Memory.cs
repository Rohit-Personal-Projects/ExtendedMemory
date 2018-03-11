using System;
using System.Collections.Generic;
using System.ComponentModel;
using Couchbase.Lite;
using Newtonsoft.Json;

namespace ExtendedMemory.Models
{
    public class Memory
    {
        public string ID { get; set; }

        public string Text { get; set; }

        public List<string> People { get; set; } = new List<string>();

        public List<string> Tags { get; set; } = new List<string>();

        public Location Location { get; set; }

        public DateTime DateTime { get; set; }

        public Memory() { }

        //public static IDictionary<string, object> MemoryToDictionary(Memory memory)
        //{
        //    var dict = new Dictionary<string, object>();
        //    foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(memory))
        //    {
        //        dict.Add(prop.Name, prop.GetValue(memory));
        //    }

        //    //var dict = new Dictionary<string, object>();
        //    //foreach (var props in memory.GetType().GetProperties())
        //    //{
        //    //    dict.Add(props.Name, props.GetValue(memory));
        //    //}
        //    return dict;
        //}

        public static Memory DictToMemory(QueryRow row)
        {
            var m = new Memory();

            Type type = typeof(Memory);
            var result = (Memory)Activator.CreateInstance(type);
            var dict = row.Document.UserProperties;

            foreach (var item in dict)
            {
                var key = type.GetProperty(item.Key);
                var val = item.Value?.ToString();
                        
                if (!String.IsNullOrWhiteSpace(val))
                {
                    switch (item.Key)
                    {
                        case nameof(m.ID):
                        case nameof(m.Text):
                            key.SetValue(result, val, null);
                            break;

                        case nameof(m.People):
                        case nameof(m.Tags):
                            key.SetValue(result, JsonConvert.DeserializeObject<List<string>>(val), null);
                            break;

                        case nameof(m.DateTime):
                            key.SetValue(result, Convert.ToDateTime(val), null);
                            break;

                        case nameof(m.Location):
                            key.SetValue(result, JsonConvert.DeserializeObject<Location>(val), null);
                            break;

                        default:
                            throw new Exception("Can't convert " + val);
                    }
                }
            }

            return result;
        }

        public Memory(QueryRow row)
        {
            var m = new Memory();
            var properties = new Dictionary<string, object>();
            foreach (PropertyDescriptor x in TypeDescriptor.GetProperties(m))
            {
                properties.Add(x.Name, x.GetValue(row));
            }
            //var m2 = JsonConvert.DeserializeObject<Memory>(row.Document.UserProperties);

            Text = row.Document.UserProperties[nameof(m.Text)]?.ToString();
            //People = JsonConvert.DeserializeObject<List<string>>(row.Document.UserProperties[nameof(m.People)];
            Tags = (List<string>) row.Document.UserProperties[nameof(m.Tags)];
            DateTime = Convert.ToDateTime(row.Document.UserProperties[nameof(m.DateTime)]);
            Location = (Location) row.Document.UserProperties[nameof(m.Location)];
        }

        public override string ToString()
        {
            return string.Format(
                "[Memory: ID={0}, Text={1}, Date={2}, City={3}, State={4}, Country={5}, People=[{6}], Tags=[{7}]]", 
                ID, Text, DateTime, Location?.City, Location?.State, Location?.Country, String.Join(", ", People), String.Join(", ", Tags));
        }
    }
}

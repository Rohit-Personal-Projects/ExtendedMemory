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

        public override string ToString()
        {
            return string.Format(
                "[Memory: ID={0}, Text={1}, Date={2}, City={3}, State={4}, Country={5}, People=[{6}], Tags=[{7}]]", 
                ID, Text, DateTime, Location?.City, Location?.State, Location?.Country, String.Join(", ", People), String.Join(", ", Tags));
        }
    }
}

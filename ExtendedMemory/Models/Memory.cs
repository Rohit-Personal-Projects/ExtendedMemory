using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        /// <summary>
        /// Entire memory object converted to a string; used for display on the search results page.
        /// </summary>
        public string MemoryDetails()
        {
            var res = new StringBuilder();

            if (People != null && People.Any())
            {
                res.Append($"\nWith {String.Join(", ", People)}");
            }
            if (Location != null)
            {
                var loc = Location.ToString();
                if (!string.IsNullOrWhiteSpace(loc))
                {
                    res.Append($"\nIn {loc}");
                }
            }
            res.Append($"\nOn {DateTime.Date.ToShortDateString()} at {DateTime.ToString("hh:mm tt")}");
            if (Tags != null && Tags.Any())
            {
                res.Append($"\nTags: {String.Join(", ", Tags)}");
            }

            return res.Remove(0, 1).ToString();
        }

        public override string ToString()
        {
            return Text;
        }

        public bool CustomEquals(Memory m)
        {
            return this.Text == m.Text &&
                       this.ID == m.ID &&
                       this.DateTime == m.DateTime &&
                       this.Location == m.Location &&
                       this.People == m.People &&
                       this.Tags == m.Tags;
        }
    }
}

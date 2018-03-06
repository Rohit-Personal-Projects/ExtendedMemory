using System;
using System.Collections.Generic;

namespace ExtendedMemory.Models
{
    public class Memory
    {
        public int ID { get; set; }

        public string Text { get; set; }

        public List<string> People { get; set; } = new List<string>();

        public List<string> Tags { get; set; } = new List<string>();

        public Location Location { get; set; }

        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return string.Format(
                "[Memory: ID={0}, Text={1}, Date={2}, City={3}, State={4}, Country={5}, People=[{6}], Tags=[{7}]]", 
                ID, Text, DateTime, Location?.City, Location?.State, Location?.Country, String.Join(", ", People), String.Join(", ", Tags));
        }
    }
}

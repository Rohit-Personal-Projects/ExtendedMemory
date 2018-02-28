using System;
using System.Collections.Generic;
using SQLite;

namespace ExtendedMemory.Models
{
    public class Memory
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public List<string> People { get; set; } = new List<string>();

        public List<string> Tags { get; set; } = new List<string>();

        public override string ToString()
        {
            return string.Format(
                "[Memory: ID={0}, Text={1}, Date={2}, City={3}, State={4}, Country={5}, People=[{6}], Tags=[{7}]]", 
                ID, Text, Date, City, State, Country, String.Join(", ", People), String.Join(", ", Tags));
        }
    }
}

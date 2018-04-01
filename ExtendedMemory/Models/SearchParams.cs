using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ExtendedMemory.Models
{
    public class SearchParams
    {
        public List<string> Memory { get; set; } = new List<string>();

        public List<string> People { get; set; } = new List<string>();

        public List<string> Tags { get; set; } = new List<string>();

        public Location Location { get; set; } = new Location();

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }
    }
}

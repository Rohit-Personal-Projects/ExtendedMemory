using System.Collections.Generic;
using Xamarin.Forms;

namespace ExtendedMemory.Models
{
    public class SearchParams
    {
        public List<string> Memory { get; set; } = new List<string>();

        public List<string> People { get; set; } = new List<string>();

        public List<string> Tags { get; set; } = new List<string>();

        public Location Location { get; set; }

        public DatePicker FromDate { get; set; }

        public DatePicker ToDate { get; set; }

        public TimePicker FromTime { get; set; }

        public TimePicker ToTime { get; set; }
    }
}

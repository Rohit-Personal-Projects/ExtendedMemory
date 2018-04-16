using System.Text;

namespace ExtendedMemory.Models
{
    public class Location
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            var loc = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(City))
            {
                loc.Append(City + ", ");
            }
            if (!string.IsNullOrWhiteSpace(State))
            {
                loc.Append(State + ", ");
            }
            if (!string.IsNullOrWhiteSpace(Country))
            {
                loc.Append(Country);
            }

            return loc.ToString();
        }
	}
}
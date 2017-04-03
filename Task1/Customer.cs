using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Customer : IFormattable
    {
        public Customer() : this(string.Empty, string.Empty, default(decimal))
        {
        }

        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        public string Name { get; set; }

        public string ContactPhone { get; set; }

        public decimal Revenue { get; set; }

        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";
            if (ReferenceEquals(formatProvider, null))
                formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "NPR": return string.Format(formatProvider, "Customer record: {0}, {1}, {2}", Name, ContactPhone, Revenue);
                case "NP": return string.Format(formatProvider, "Customer record: {0}, {1}", Name, ContactPhone);
                case "NRP": return string.Format(formatProvider, "Customer record: {0}, {1}, {2}", Name, Revenue, ContactPhone);
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }       
        }
    }
}
    
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

        public string Name { get; private set; }

        public string ContactPhone { get; private set; }

        public decimal Revenue { get; private set; }

        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";
            if (ReferenceEquals(formatProvider, null))
                formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "NPR": return string.Format(formatProvider, $"{Name}, {ContactPhone}, {Revenue}");
                case "NP": return string.Format(formatProvider, $"{Name}, {ContactPhone}");
                case "NRP": return string.Format(formatProvider, $"{Name}, {Revenue}, {ContactPhone}");
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }       
        }
    }
}
    
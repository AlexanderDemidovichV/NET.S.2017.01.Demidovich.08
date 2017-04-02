using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1.Tests
{
    public class CustomerFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType) => formatType == typeof(ICustomFormatter) ? this : null;

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(arg, null))
                throw new ArgumentNullException();

            if (!this.Equals(formatProvider))
                return null;

            if (string.IsNullOrEmpty(format) || !(arg is Customer))
                return string.Format(null, "{0:" + format + "}", arg);

            Customer customer = (Customer)arg;

            switch (format.ToUpperInvariant())
            {
                case "R": return string.Format(formatProvider, $"{customer.Revenue}");
                default: return string.Format(null, "{0:" + format + "}", arg);
            }
        }
    }
}

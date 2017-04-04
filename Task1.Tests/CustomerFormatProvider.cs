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
        private readonly IFormatProvider parent;

        public CustomerFormatProvider(IFormatProvider parent = null)
        {
            this.parent = parent ?? CultureInfo.CurrentCulture;
        }

        public object GetFormat(Type formatType) =>
            formatType == typeof(ICustomFormatter) ? this : null;

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(arg, null))
                throw new ArgumentNullException();

            if (!this.Equals(formatProvider))
                return null;

            if (string.IsNullOrEmpty(format) || !(arg is Customer))
                return string.Format(parent, "{0:" + format + "}", arg);

            Customer customer = (Customer)arg;

            switch (format.ToUpperInvariant())
            {
                case "NPRD": return string.Format(formatProvider, "Customer record: {0}, {1}, {2:c}", customer.Name, customer.ContactPhone, customer.Revenue);
                case "NRD": return string.Format(formatProvider, "Customer record: {0}, {1:c}", customer.Name, customer.Revenue);
                case "RD": return string.Format(formatProvider, "Customer record: {0:c}", customer.Revenue);
                default: return string.Format(parent, "{0:" + format + "}", arg);
            }
        }
    }
}

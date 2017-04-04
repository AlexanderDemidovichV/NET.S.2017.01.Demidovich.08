using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Class <paramref name="Customer"/> contains general customer's information.
    /// </summary>
    /// <seealso cref="System.IFormattable" />
    public class Customer : IFormattable
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer() : this(string.Empty, string.Empty, default(decimal))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class using the specified strings and deimal value.
        /// </summary>
        /// <param name="name">The customer's name.</param>
        /// <param name="contactPhone">The contact phone.</param>
        /// <param name="revenue">The revenue.</param>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Contains value of customer's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Contains value of customer's phone number.
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// Contains value of customer's revenue.
        /// </summary>
        public decimal Revenue { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Converts the value of this instance to a String.
        /// </summary>
        /// <returns>A string whose value is the same as this instance.</returns>
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="System.FormatException">The format string is not supported.</exception>
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";
            if (ReferenceEquals(formatProvider, null))
                formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "NPR": return string.Format(formatProvider, "{0}, {1}, {2:N}", Name, ContactPhone, Revenue);
                case "NP": return string.Format(formatProvider, "{0}, {1}", Name, ContactPhone);
                case "NR": return string.Format(formatProvider, "{0}, {1:N}", Name, Revenue);
                case "PR": return string.Format(formatProvider, "{0}, {1:N}", ContactPhone, Revenue);
                case "N": return string.Format(formatProvider, "{0}", Name);
                case "P": return string.Format(formatProvider, "{0}", ContactPhone);
                case "R": return string.Format(formatProvider, "{0:N}", Revenue);
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }       
        }

        #endregion
    }
}
    
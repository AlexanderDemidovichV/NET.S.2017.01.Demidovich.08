using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    public class CustomerTests
    {
        public IEnumerable<TestCaseData> CustomerFormatting_TestData
        {
            get
            {
                Customer customer = new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 };

                yield return new TestCaseData("G", customer).Returns("Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00");
                yield return new TestCaseData("NPR", customer).Returns("Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00");
                yield return new TestCaseData("NP", customer).Returns("Jeffrey Richter, +1 (425) 555-0100");
                yield return new TestCaseData("NR", customer).Returns("Jeffrey Richter, 1,000,000.00");
                yield return new TestCaseData("PR", customer).Returns("+1 (425) 555-0100, 1,000,000.00");
                yield return new TestCaseData("N", customer).Returns("Jeffrey Richter");
                yield return new TestCaseData("P", customer).Returns("+1 (425) 555-0100");
                yield return new TestCaseData("R", customer).Returns("1,000,000.00");
                yield return new TestCaseData("F", customer).Throws(typeof(FormatException));
            }
        }

        [Test, TestCaseSource("CustomerFormatting_TestData")]
        public static string CustomerFormatting_Test_Yeild(string format, Customer customer)
        {
            return string.Format("{0:" + format + "}", customer);
        }

        public IEnumerable<TestCaseData> CustomerFormatProvider_TestData
        {
            get
            {
                Customer customer = new Customer() { Name = "Jeffrey Richter", ContactPhone = "+1 (425) 555-0100", Revenue = 1000000 };
                IFormatProvider fp = new CustomerFormatProvider();

                yield return new TestCaseData(fp, "NPRd", customer).Returns("Customer record: Jeffrey Richter, +1 (425) 555-0100, $1,000,000.00");
                yield return new TestCaseData(fp, "NRd", customer).Returns("Customer record: Jeffrey Richter, $1,000,000.00");
                yield return new TestCaseData(fp, "Rd", customer).Returns("Customer record: $1,000,000.00");
                yield return new TestCaseData(fp, "G", customer).Returns("Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00");
                yield return new TestCaseData(fp, "NPR", customer).Returns("Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00");
                yield return new TestCaseData(fp, "NP", customer).Returns("Jeffrey Richter, +1 (425) 555-0100");
                yield return new TestCaseData(fp, "NR", customer).Returns("Jeffrey Richter, 1,000,000.00");
                yield return new TestCaseData(fp, "PR", customer).Returns("+1 (425) 555-0100, 1,000,000.00");
                yield return new TestCaseData(fp, "N", customer).Returns("Jeffrey Richter");
                yield return new TestCaseData(fp, "P", customer).Returns("+1 (425) 555-0100");
                yield return new TestCaseData(fp, "R", customer).Returns("1,000,000.00");
                yield return new TestCaseData(fp, "F", customer).Throws(typeof(FormatException));

            }
        }

        [Test, TestCaseSource("CustomerFormatProvider_TestData")]
        public static string CustomerFormatProvider_Test_Yeild(IFormatProvider formatProvider, string format, Customer customer)
        {
            return string.Format(formatProvider, "{0:" + format + "}", customer);
        }




    }
}

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
            }
        }

        [Test, TestCaseSource("CustomerFormatting_TestData")]
        public static string testCustomerFormatting(string format, IFormattable customer)
        {
            return string.Format(format, customer);
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Tests.XUnit.TestData
{
    public class ControllersTestData
    {
        public static IEnumerable<object[]> CustomerIdAndName
        {
            get
            {
                yield return new object[] { 1, "Maciej" };
                yield return new object[] { 3, "Hieronim" };
                yield return new object[] { 2, "Piotr" };

            }
        }
    }
}

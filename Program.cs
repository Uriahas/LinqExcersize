using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace LinqExcersize {
    class Program {
        /// <summary>
        /// Prints a list of contact names followed by their total amount
        /// The total amount formula: Σ=(UnitPrice - UnitPrice * Dicount) * Quantity
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            // your code goes here
        }
        /// <summary>
        /// Returns an sequence of arrays
        /// Each element in a sequence contains six values:
        /// 0: Contact Name
        /// 1: Product Name
        /// 2: Order Date
        /// 3: UnitPrice
        /// 4: Quantity
        /// 5: Discount
        /// </summary>
        /// <returns></returns>
        static IEnumerable<object[]> ReadFromFile() {
            return File.ReadLines("data.txt")
                .Select(l => l.Split(','))
                .Select(a => new object[] {
                    a[0],
                    a[1],
                    DateTime.Parse(a[2]),
                    decimal.Parse(a[3]),
                    short.Parse(a[4]),
                    float.Parse(a[5])
                });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LinqExcersize {
    class Program {
        static void Main(string[] args) {
            IQueryable<Model> q = ReadFromFile();
            Test(q, new[] { new[] { "ContactName", "Mario Pontes", "equal" } }, 32);
            Test(q, new[] { 
                new[] { "ContactName", "Paul Henriot", "equal" }, 
                new[] { "ProductName", "Queso Cabrales", "not equal" } 
            }, 9);
            Test(q, new[] { new[] {"ProductName", "'s", "contains" } }, 187);
        }
        static void Test(IQueryable<Model> q, object[][] filter, int expected) {
            int actual = q.ApplyMyFilter(filter).Count();
            var tmp = q.ApplyMyFilter(filter).ToList();
            Debug.Assert(actual == expected, PrintFilter(filter), $"Actual value is {actual}");
        }
        static string PrintFilter(object[][] filter) {
            return string.Join("and", FilterToString(filter));
        }
        static IEnumerable<string> FilterToString(object[][] filter) {
            return filter.Select(c => $"({c[0]} {c[2]} {c[1]})");
        }
        static IQueryable<Model> ReadFromFile() {
            return File.ReadLines("data.txt")
                .Select(l => l.Split(','))
                .Select(a => new Model() {
                    ContactName = a[0],
                    ProductName = a[1],
                    OrderDate = DateTime.Parse(a[2]),
                    UnitPrice = decimal.Parse(a[3]),
                    Quantity = short.Parse(a[4]),
                    Discount = float.Parse(a[5])
                }).AsQueryable();
        }
    }
}

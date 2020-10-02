using System;
using System.Linq;

namespace LinqExcersize {
    class Program {
        static void Main(string[] args) {
            var q = from m in new QueryableModel<Model>()
                    where m.ContactName == "Paul Henriot"
                    select new { m.ProductName, m.OrderDate, m.UnitPrice, m.Discount, m.Quantity };
            foreach(var model in q) {
                Console.WriteLine($"{model.ProductName}: {(model.UnitPrice - model.UnitPrice * (decimal)model.Discount) * model.Quantity}");
            }
        }
    }
}

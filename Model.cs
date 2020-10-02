using System;

namespace LinqExcersize {
    public class Model {
        public int ID { get; set; }
        public string ContactName { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}

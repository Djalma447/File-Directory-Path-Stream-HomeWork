using System.Globalization;

namespace Course.Entities
{
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Item(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double Total()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return Name
                + ","
                + Total().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}

Address usaAddress = new Address("123 Main St", "New York", "NY", "USA");
Address nonUsaAddress = new Address("456 Maple Ave", "Toronto", "Ontario", "Canada");

Customer alice = new Customer("Alice Johnson", usaAddress);
Customer bob = new Customer("Bob Smith", nonUsaAddress);

Product laptop = new Product("Laptop", "TEC-001", 999.99, 1);
Product mouse = new Product("Wireless Mouse", "TEC-002", 25.50, 2);
Product keyboard = new Product("Mechanical Keyboard", "TEC-003", 89.99, 1);
Product headphones = new Product("Headphones", "TEC-004", 149.99, 1);
Product usbCable = new Product("USB-C Cable", "TEC-005", 9.99, 3);

Order order1 = new Order(alice);
order1.AddProduct(laptop);
order1.AddProduct(mouse);
order1.AddProduct(keyboard);

Order order2 = new Order(bob);
order2.AddProduct(headphones);
order2.AddProduct(usbCable);

List<Order> orders = new List<Order> { order1, order2 };

foreach (Order order in orders)
{
    Console.WriteLine("PACKING LABEL");
    Console.WriteLine(order.GetPackingLabel());
    Console.WriteLine();
    Console.WriteLine("SHIPPING LABEL");
    Console.WriteLine(order.GetShippingLabel());
    Console.WriteLine();
    Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}");
    Console.WriteLine(new string('-', 40));
}

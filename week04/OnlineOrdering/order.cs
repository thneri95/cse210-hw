using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Product product in products)
        {
            sb.AppendLine(product.GetPackingLabel());
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }

    public double GetShippingCost()
    {
        return customer.IsInUSA() ? 5.0 : 35.0;
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }
        return total + GetShippingCost();
    }

    public string GetOrderDetails()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        sb.AppendLine(GetPackingLabel());
        sb.AppendLine("Shipping Label:");
        sb.AppendLine(GetShippingLabel());
        sb.AppendLine("Product Prices:");
        foreach (Product p in products)
        {
            sb.AppendLine($"{p.GetPackingLabel()}: {p.GetQuantity()} x ${p.GetPrice():0.00} = ${p.GetTotalCost():0.00}");
        }
        sb.AppendLine($"Shipping: ${GetShippingCost():0.00}");
        sb.AppendLine($"Total Price: ${GetTotalPrice():0.00}");
        return sb.ToString();
    }
}
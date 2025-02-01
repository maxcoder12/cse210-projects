using System;
using system.Collections.Generic;

public class Order{
    private List<Product> _products = new List<Product>();
    private Customer _customer = new Customer("", Address address);

    public Order(List<Product> products, Customer customer){
        _products = products;
        _customer = customer;
    }

    public double GetTotalCost(){
        double totalCost = 0;
        int shippingCost = 0;

        foreach (Product product in _products){
            totalCost += product.CalculateTotalPrice();
        }

        if(_customer.LivesInUsa()){
            shippingCost = 5;
        } else{
            shippingCost = 35;
        }

        return $"Total Cost = ${totalCost + shippingCost}";
    }

    public string DisplayPackingLabel(){
        string packingLabel = "";

        foreach (Product product in _products){
            packingLabel += $"Product: {product.GetName()} - ID: {product.GetProductID()}\n";
        }

        return packingLabel;
    }

    public string DisplayShippingLabel(){
        string shippingLabel = $"Name: {_customer.GetName()} - Address: {_customer.DisplayAddress()}";
    }

}
using System;

public class Customer{
    private string _name;
    private Address _address;

    public Customer(string name, Address address){
        _name = name;
        _address = address;
    }

    public string GetName(){
        return _name;
    }

    public bool LivesInUsa(){
        returns _address.LivesInUsa();
    }

    public string DisplayAddress(){
        return _address.DisplayLocation();
    }


}
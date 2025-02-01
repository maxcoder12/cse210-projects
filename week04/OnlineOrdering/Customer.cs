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
        if (_address.LivesInUsa()){
            return true;
        } else{
            return false;
        }
    }

    public string DisplayAddress(){
        return _address.DisplayLocation();
    }


}
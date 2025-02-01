using System;

public class Address{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country){
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public string GetCountry(){
        return _country;
    }

    public bool LivesInUsa(){
        if (_country.ToLower() == "usa"){
            return true;
        } else{
            return false;
        }
    }

    public string DisplayLocation(){
        return $"{_street}, {_city}, {_state}, {GetCountry()}";
    }

}
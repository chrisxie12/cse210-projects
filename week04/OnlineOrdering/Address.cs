class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public string GetStreet()
    {
        return _street;
    }

    public string GetCity()
    {
        return _city;
    }

    public string GetStateProvince()
    {
        return _stateProvince;
    }

    public string GetCountry()
    {
        return _country;
    }

    public bool IsInUSA()
    {
        return _country == "USA" || _country == "United States";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}\n{_stateProvince}\n{_country}";
    }
}

using ContainersAPBD.Exceptions;

namespace ContainersAPBD.Containers;

public class RefrigeratedContainer : Container
{
    public string _productType;
    public double _requiredTemperature;
    public double _currentTemperature;

    public RefrigeratedContainer(double maxCargoWeight, string serialNumber, string productType, double requiredTemperature) 
        : base(maxCargoWeight, serialNumber)
    {
        _productType = productType;
        _requiredTemperature = requiredTemperature;
    }

    public double LoadCargo(double cargoWeight, double temperature)
    {
        if (temperature < _requiredTemperature)
        {
            throw new Exception("Temperature is too low for the product type.");
        }

        return base.LoadCargo(cargoWeight);
    }

    public override double LoadCargo(double cargoWeight)
    {
        if (_cargoWeight + cargoWeight > _maxCargoWeight)
        {
            throw new OverfillException("Cargo weight exceeds container capacity.");
        }

        return base.LoadCargo(cargoWeight);
    }

    public new string GetInfo()
    {
        return base.GetInfo() + $", Product Type - {_productType}, Required Temperature - {_requiredTemperature}°C";
    }
    
}
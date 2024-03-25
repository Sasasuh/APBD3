using System.ComponentModel;
using ContainersAPBD.Exceptions;
using ContainersAPBD.Interfaces;

namespace ContainersAPBD.Containers;

public class Container : Interfaces.IContainer
{
    public double _cargoWeight;
    public double _maxCargoWeight;
    public string _serialNumber;

    public Container(double maxCargoWeight, string serialNumber)
    {
        _maxCargoWeight = maxCargoWeight;
        _serialNumber = serialNumber;
    }

    public virtual double LoadCargo(double cargoWeight)
    {
        if (_cargoWeight + cargoWeight > _maxCargoWeight)
        {
            throw new OverfillException("Cargo weight exceeds container capacity.");
        }

        _cargoWeight += cargoWeight;
        return _cargoWeight;
    }

    public void UnloadCargo()
    {
        _cargoWeight = 0;
    }

    public string GetInfo()
    {
        return $"Container {_serialNumber}: Cargo Weight - {_cargoWeight}kg, Max Cargo Weight - {_maxCargoWeight}kg";
    }
    
    public double GetCargoWeight()
    {
        return _cargoWeight;
    }
}
using ContainersAPBD.Interfaces;

namespace ContainersAPBD.Containers;

public class GasContainer : Container, IHazardNotifier
{

    public GasContainer(double maxCargoWeight, string serialNumber) : base(maxCargoWeight,
        serialNumber)
    {
    }
    
    public void Notify(string message)
    {
        Console.WriteLine($"Hazard Notification: {message}");
    }
    
    public override double LoadCargo(double cargoWeight)
    {
        double fillPercentage = (_cargoWeight + cargoWeight) / _maxCargoWeight * 100;

        if (fillPercentage > 50)
        {
            throw new Exception("Cannot load hazardous cargo above 50% capacity.");
        }

        return base.LoadCargo(cargoWeight);
    }
}
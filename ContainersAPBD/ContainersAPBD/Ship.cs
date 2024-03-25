using ContainersAPBD.Interfaces;

namespace ContainersAPBD;

public class Ship
{
    private string _name;
    private double _maxSpeed;
    private double _maxContainerNum;
    private double _maxWeight;
    private List<IContainer> _containers;

    public Ship(string name, double maxSpeed, double maxContainerNum, double maxWeight)
    {
        _name = name;
        _maxSpeed = maxSpeed;
        _maxContainerNum = maxContainerNum;
        _maxWeight = maxWeight;
        _containers = new List<IContainer>();
    }

    public void AddContainer(IContainer container)
    {
        if (_containers.Count < _maxContainerNum && CalculateTotalWeight() + container.LoadCargo(0) <= _maxWeight)
        {
            _containers.Add(container);
        }
        else
        {
            Console.WriteLine("Cannot add container: Ship is at full capacity.");
        }
    }

    public void RemoveContainer(IContainer container)
    {
        _containers.Remove(container);
    }
    

    public void LoadContainers(List<IContainer> containers)
    {
        foreach (var container in containers)
        {
            AddContainer(container);
        }
    }

    public void UnloadContainer(IContainer container)
    {
        container.UnloadCargo();
        _containers.Remove(container);
    }

    public string GetInfo()
    {
        string containersInfo = "";
        foreach (var container in _containers)
        {
            containersInfo += container.GetInfo() + "\n";
        }
        return $"Ship Name: {_name}\nMax Speed: {_maxSpeed} knots\nMax Container Number: {_maxContainerNum}\nMax Weight: {_maxWeight} tons\nContainers:\n{containersInfo}";
    }

    private double CalculateTotalWeight()
    {
        double totalWeight = 0;
        foreach (var container in _containers)
        {
            totalWeight += container.GetCargoWeight();
        }
        return totalWeight;
    }
}

namespace ContainersAPBD.Interfaces;

public interface IContainer
{
    double LoadCargo(double cargoWeight);
    void UnloadCargo();
    string GetInfo();
    double GetCargoWeight();


}
using ContainersAPBD;
using ContainersAPBD.Containers;

class Program
{
    static void Main(string[] args)
    {
        Ship ship1 = new Ship("Ship 1", 20, 50, 50000);
        Ship ship2 = new Ship("Ship 2", 15, 40, 40000);

        LiquidContainer liquidContainer1 = new LiquidContainer(10000, "KON-L-1");
        GasContainer gasContainer1 = new GasContainer(8000, "KON-G-1");
        RefrigeratedContainer refrigeratedContainer1 = new RefrigeratedContainer(15000, "KON-C-1", "Milk", 5);

        try
        {
            ship1.AddContainer(liquidContainer1);
            liquidContainer1.LoadCargo(5000); 
            ship1.AddContainer(gasContainer1);
            gasContainer1.LoadCargo(3000); 
            ship2.AddContainer(refrigeratedContainer1);
            refrigeratedContainer1.LoadCargo(7000); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Informacje o statku 1:");
        Console.WriteLine(ship1.GetInfo());

        Console.WriteLine("Informacje o statku 2:");
        Console.WriteLine(ship2.GetInfo());

        ship1.RemoveContainer(liquidContainer1);
        ship2.AddContainer(liquidContainer1);

        Console.WriteLine("Po przeniesieniu kontenera z statku 1 na statek 2:");
        Console.WriteLine("Informacje o statku 1:");
        Console.WriteLine(ship1.GetInfo());

        Console.WriteLine("Informacje o statku 2:");
        Console.WriteLine(ship2.GetInfo());

        Console.WriteLine("Próba dodania kolejnego kontenera na statek 2:");
        try
        {
            ship2.AddContainer(new LiquidContainer(10000, "KON-L-2"));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
    }
}
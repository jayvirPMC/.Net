using System;

public class Program {
    public static void Main(string[] args) {

        Car maruti = new Car();
        maruti.Name = "alto";
        maruti.NoOfWheels = 4;
        maruti.TopSpeed = 100;
        Console.WriteLine($"Car name: {maruti.Name}" );
        Console.WriteLine($"Car wheels: {maruti.NoOfWheels}" );
        Console.WriteLine($"Car Top speed: {maruti.TopSpeed}" );
        maruti.applyBreak();
        maruti.makeSound();

        Bicycle atlas = new Bicycle();
        atlas.Name = "CrossRoad";
        atlas.NoOfWheels = 2;
        atlas.TopSpeed = 30;
        Console.WriteLine($"Bicycle name: {atlas.Name}");
        Console.WriteLine($"Bicycle wheels: {atlas.NoOfWheels}");
        Console.WriteLine($"Bicycle Top Speed: {atlas.TopSpeed}");
        atlas.applyBreak();
        atlas.makeSound();
    }
}

interface IBreak {
    void applyBreak();
}

public class Vehicle {
    private string name = "";
    private int noOfWheels = 0;
    private int topSpeed = 0;

    public string Name { get; set; }
    public int NoOfWheels { get; set; }
    public int TopSpeed { get; set; }

    public void engineStart() {
        Console.WriteLine("Vehicle is started..");
    }

    public virtual void makeSound() {
        Console.WriteLine("pip..");
    }
}

public class Car : Vehicle, IBreak {

    public override void makeSound() {
        Console.WriteLine("Car pip..");
    }

    public void applyBreak() {
        Console.WriteLine("Car Break is Applied");
    }
}

public class Bicycle : Vehicle, IBreak {

    public override void makeSound() {
        Console.WriteLine("Bicycle pip..");
    }

    public void applyBreak() {
        Console.WriteLine("Car Break is Applied");
    }
}
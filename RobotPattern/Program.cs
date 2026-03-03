using RobotPattern.Context;

namespace RobotPattern;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("──────────────────────────────────");
        Console.WriteLine("      ДЕМОНСТРАЦИЯ РОБОТА");
        Console.WriteLine("──────────────────────────────────");
        Console.WriteLine();
        
        var robot = new WarehouseRobot();
        Console.WriteLine($"[Робот] Инициализирует батарею: {robot.BatteryLevel}%");
        Console.WriteLine();
        
        Console.WriteLine("Сценарий 1: Обычная работа");
        Console.WriteLine("──────────────────────────────────");
        
        await robot.Move();           
        await robot.Move();           
        await robot.PickupCargo();   
        await robot.Move();           
        await robot.Move();           
        await robot.DropCargo();       

        Console.WriteLine();
        
        Console.WriteLine("Сценарий 2: Низкий заряд");
        Console.WriteLine("──────────────────────────────────");
        
        robot.BatteryLevel = 15;
        robot.HasCargo = false;
        Console.WriteLine($"[Робот] Заряд батареи: {robot.BatteryLevel}%");
        
        await robot.Move();           
        await robot.Charge();         

        Console.WriteLine();
        
        Console.WriteLine("Сценарий 3: Ошибка батарейки");
        Console.WriteLine("──────────────────────────────────");
        
        robot.BatteryLevel = 5;
        robot.HasCargo = false;
        Console.WriteLine($"[Робот] Заряд батареи: {robot.BatteryLevel}%");
        
        await robot.Move();
        await robot.Move();

        Console.WriteLine();
        
        Console.WriteLine("Сценарий 4: Непонятные действия");
        Console.WriteLine("──────────────────────────────────");
        
        robot.BatteryLevel = 100;
        robot.HasCargo = false;
        
        await robot.DropCargo();   
        await robot.PickupCargo();  
        await robot.Charge();          
        await robot.Move();         

        Console.WriteLine("\nВсё");
    }
}
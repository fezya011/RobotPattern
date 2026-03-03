using RobotPattern.Context;
using RobotPattern.Interfaces;

namespace RobotPattern.States;

public class MovingToDeliveryState : IRobotState
{
    private WarehouseRobot _robot { get; set; }
    
    public MovingToDeliveryState(WarehouseRobot robot) 
    { 
        _robot = robot; 
    }
    
    public async Task Enter() 
    { 
        Console.WriteLine("Начало движения к точке доставки");
        await Move();
    }

    public async Task Move()
    {
        _robot.BatteryLevel -= 5;
        Console.WriteLine($"Едем с грузом... Заряд: {_robot.BatteryLevel}%");
        await Task.Delay(2000);

        if (_robot.BatteryLevel < 10)
        {
            _robot.SetState(new ChargingState(_robot));
            return;
        }
        
        _robot.SetState(new UnloadingState(_robot));
    }
    
    public async Task PickupCargo() 
    { 
        Console.WriteLine("Груз уже загружен.");
        await Task.CompletedTask;
    }
    
    public async Task DropCargo() 
    { 
        Console.WriteLine("Точка выгрузки далеко...");
        await Task.CompletedTask;
    }
    
    public async Task Charge()
    {
        Console.WriteLine("Нельзя заряжаться во время движения");
        await Task.CompletedTask;
    }
    
    public async Task FinishTask()
    {
        _robot.SetState(new IdleState(_robot));
        await Task.CompletedTask;
    }
    
    public async Task HandleError()
    {
        _robot.SetState(new ErrorState(_robot));
        await Task.CompletedTask;
    }
}
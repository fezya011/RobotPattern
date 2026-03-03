using RobotPattern.Context;
using RobotPattern.Interfaces;

namespace RobotPattern.States;

public class ChargingState : IRobotState
{
    private WarehouseRobot _robot { get; set; }
    
    public ChargingState(WarehouseRobot robot) 
    { 
        _robot = robot; 
    }

    public async Task Enter()
    {
        await Charge();
    }

    public async Task Charge()
    {
        Console.WriteLine("Идет зарядка подождите...");
        await Task.Delay(2500);
        
        _robot.BatteryLevel = 100;
        _robot.SetState(new IdleState(_robot));
    }
    
    public async Task Move() 
    { 
        Console.WriteLine("Движение недоступно. Идет зарядка");
        await Task.CompletedTask;
    }
    
    public async Task PickupCargo() 
    { 
        Console.WriteLine("Погрузка недоступна. Идет зарядка");
        await Task.CompletedTask;
    }
    
    public async Task DropCargo() 
    { 
        Console.WriteLine("Выгрузка недоступна. Идет зарядка");
        await Task.CompletedTask;
    }
    
    public async Task FinishTask()
    {
        Console.WriteLine("Зарядка не является задачей");
        await Task.CompletedTask;
    }
    
    public async Task HandleError()
    {
        _robot.SetState(new ErrorState(_robot));
        await Task.CompletedTask;
    }
}
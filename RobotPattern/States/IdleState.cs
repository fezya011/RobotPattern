using RobotPattern.Context;
using RobotPattern.Interfaces;

namespace RobotPattern.States;

public class IdleState : IRobotState
{
    private WarehouseRobot _robot { get; set; }
    
    public IdleState(WarehouseRobot robot) 
    { 
        _robot = robot; 
    }

    public async Task Enter() 
    { 
        Console.WriteLine("Робот стоит на базе в режиме ожидания");
        await Task.CompletedTask;
    }
    
    public async Task Move()
    {
        if (_robot.BatteryLevel < 20)
            _robot.SetState(new ChargingState(_robot));
        else
            _robot.SetState(new MovingToTargetState(_robot));
        await Task.CompletedTask;
    }

    public async Task PickupCargo() 
    { 
        Console.WriteLine("Груза нет рядом. Сначала нужно доехать");
        await Task.CompletedTask;
    }
    
    public async Task DropCargo() 
    { 
        Console.WriteLine("Нечего выгружать");
        await Task.CompletedTask;
    }
    
    public async Task Charge()
    {
        _robot.SetState(new ChargingState(_robot));
        await Task.CompletedTask;
    }
    
    public async Task FinishTask()
    {
        Console.WriteLine("Нет активной задачи");
        await Task.CompletedTask;
    }
    
    public async Task HandleError()
    {
        _robot.SetState(new ErrorState(_robot));
        await Task.CompletedTask;
    }
}
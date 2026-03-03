using RobotPattern.Context;
using RobotPattern.Interfaces;

namespace RobotPattern.States;

public class UnloadingState : IRobotState
{
    private WarehouseRobot _robot { get; set; }
    
    public UnloadingState(WarehouseRobot robot) 
    { 
        _robot = robot; 
    }

    public async Task Enter()
    {
        await DropCargo();
    }

    public async Task DropCargo()
    {
        Console.WriteLine("Идет выгрузка... Подождите");
        await Task.Delay(1500);
        
        _robot.HasCargo = false;
        _robot.SetState(new IdleState(_robot));
    }
    
    public async Task Move() 
    { 
        Console.WriteLine("Идет выгрузка. Нельзя двигаться");
        await Task.CompletedTask;
    }
    
    public async Task PickupCargo()
    {
        Console.WriteLine("Нельзя взять груз во время выгрузки");
        await Task.CompletedTask;
    }
    
    public async Task Charge()
    {
        Console.WriteLine("Нельзя заряжаться во время выгрузки");
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
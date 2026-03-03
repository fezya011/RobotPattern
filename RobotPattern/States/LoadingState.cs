using RobotPattern.Context;
using RobotPattern.Interfaces;

namespace RobotPattern.States;

public class LoadingState : IRobotState
{
    private WarehouseRobot _robot { get; set; }
    
    public LoadingState(WarehouseRobot robot) 
    { 
        _robot = robot; 
    }

    public async Task Enter()
    {
        await PickupCargo();
    }

    public async Task PickupCargo()
    {
        Console.WriteLine("Подъем груза... Подождите");
        await Task.Delay(1500);
        
        _robot.HasCargo = true;
        _robot.SetState(new MovingToDeliveryState(_robot));
    }
    
    public async Task Move() 
    { 
        Console.WriteLine("Идет загрузка... Нельзя двигаться");
        await Task.CompletedTask;
    }
    
    public async Task DropCargo()
    {
        Console.WriteLine("Нельзя выгрузить - груз еще не взят");
        await Task.CompletedTask;
    }
    
    public async Task Charge()
    {
        Console.WriteLine("Нельзя заряжаться во время загрузки");
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
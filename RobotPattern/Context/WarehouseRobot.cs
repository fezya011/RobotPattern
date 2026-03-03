using RobotPattern.Interfaces;
using RobotPattern.States;

namespace RobotPattern.Context;

public class WarehouseRobot
{
    public IRobotState CurrentState { get; private set; }
    public int BatteryLevel { get; set; }
    public bool HasCargo { get; set; }
    
    public WarehouseRobot()
    {
        CurrentState = new IdleState(this);
        BatteryLevel = 100;
        HasCargo = false;
    }
    
    public void SetState(IRobotState newState)
    {
        CurrentState = newState;
        Console.WriteLine($"[Робот] Состояние: {newState.GetType().Name.Replace("State", "")}");
    }

    public async Task Move()
    {
        Console.WriteLine("[Пользователь] Команда: Move");
        await CurrentState.Move();
    }

    public async Task PickupCargo()
    {
        Console.WriteLine("[Пользователь] Команда: Pickup Cargo");
        await CurrentState.PickupCargo();
    }

    public async Task DropCargo()
    {
        Console.WriteLine("[Пользователь] Команда: Drop Cargo");
        await CurrentState.DropCargo();
    }

    public async Task Charge()
    {
        Console.WriteLine("[Пользователь] Команда: Charge");
        await CurrentState.Charge();
    }
}
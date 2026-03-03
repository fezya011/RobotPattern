using RobotPattern.Context;
using RobotPattern.Interfaces;

namespace RobotPattern.States;

public class ErrorState : IRobotState
{
    private readonly WarehouseRobot _robot;

    public ErrorState(WarehouseRobot robot) 
    { 
        _robot = robot; 
    }

    public async Task Enter()
    {
        await HandleError();
    }

    public async Task HandleError()
    {
        Console.WriteLine("Система перезагружается... Проверка систем.");
        await Task.Delay(3000);
        _robot.SetState(new IdleState(_robot));
    }

    public async Task Move() 
    { 
        Console.WriteLine("Робот неисправен. Движение невозможно");
        await Task.CompletedTask;
    }
    
    public async Task PickupCargo() 
    { 
        Console.WriteLine("Робот неисправен. Погрузка невозможна");
        await Task.CompletedTask;
    }
    
    public async Task DropCargo() 
    { 
        Console.WriteLine("Робот неисправен. Выгрузка невозможна");
        await Task.CompletedTask;
    }
    
    public async Task Charge() 
    { 
        Console.WriteLine("Робот неисправен. Зарядка невозможна");
        await Task.CompletedTask;
    }
    
    public async Task FinishTask() 
    { 
        Console.WriteLine("Робот неисправен. Задача не может быть завершена");
        await Task.CompletedTask;
    }
}
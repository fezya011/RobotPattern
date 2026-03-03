using RobotPattern.Context;

namespace RobotPattern.Interfaces;

public interface IRobotState
{
    Task Move();
    Task PickupCargo();
    Task DropCargo();
    Task Charge();
    Task FinishTask();
    Task HandleError();
    Task Enter();
}
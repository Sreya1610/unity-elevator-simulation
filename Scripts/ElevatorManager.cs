using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    public ElevatorController[] elevators;

    public void RequestElevator(int floor)
    {
        ElevatorController bestElevator = null;
        int smallestDistance = int.MaxValue;

        foreach (ElevatorController elevator in elevators)
        {
            int distance = Mathf.Abs(elevator.currentFloor - floor);

            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                bestElevator = elevator;
            }
        }

        if (bestElevator != null)
        {
            bestElevator.AddRequest(floor);
        }
    }
}
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public ElevatorManager manager;
    public int floorNumber;

    public void PressButton()
    {
        manager.RequestElevator(floorNumber);
    }
}
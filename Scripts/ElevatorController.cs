using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float speed = 3f;
    public Transform[] floors;

    public int currentFloor = 0;

    private Queue<int> requests = new Queue<int>();
    private bool isMoving = false;

    public bool IsMoving()
    {
        return isMoving;
    }

    public void AddRequest(int floor)
    {
        if (!requests.Contains(floor))
        {
            requests.Enqueue(floor);
        }
    }

    void Update()
    {
        if (!isMoving && requests.Count > 0)
        {
            int targetFloor = requests.Dequeue();
            StartCoroutine(MoveElevator(targetFloor));
        }
    }

    IEnumerator MoveElevator(int targetFloor)
    {
        isMoving = true;

        float targetY = floors[targetFloor].position.y;

        while (Mathf.Abs(transform.position.y - targetY) > 0.02f)
        {
            Vector3 pos = transform.position;

            pos.y = Mathf.MoveTowards(
                transform.position.y,
                targetY,
                speed * Time.deltaTime
            );

            transform.position = pos;

            yield return null;
        }

        currentFloor = targetFloor;

        isMoving = false;
    }
}
using System.Collections.Generic;
using UnityEngine;

public class QueueControl : MonoBehaviour
{
    public Transform queueStartPoint;
    public List<GameObject> customersInQueue = new List<GameObject>();

    private void Update()
    {
        for(int i = 0; i < customersInQueue.Count; i++)
        {
            customersInQueue[i].transform.position = new Vector2(queueStartPoint.position.x - (1.3f * i), queueStartPoint.position.y);
        }
    }
}

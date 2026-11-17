using Assets.Code.Round;
using System.Collections.Generic;
using UnityEngine;

public class QueueControl : MonoBehaviour
{
    public static QueueControl Instance;
    public Transform queueStartPoint;
    public List<GameObject> customersInQueue = new List<GameObject>();

    public GameObject currentCustomer;

    private void Start()
    {
        Instance = this;
    }
    private void Update()
    {
        for(int i = 0; i < customersInQueue.Count; i++)
        {
            customersInQueue[i].transform.position = new Vector2(queueStartPoint.position.x - (1.3f * i), queueStartPoint.position.y);
        }

        if(customersInQueue.Count != 0)
        {
            currentCustomer = customersInQueue[0];
        } else
        {
            currentCustomer = null;
            
        }
    }
}

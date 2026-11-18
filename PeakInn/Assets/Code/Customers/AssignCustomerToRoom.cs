using Assets.Code.Rooms;
using Assets.Code.Round;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Code.Customers
{
    class AssignCustomerToRoom : MonoBehaviour
    {
        public static AssignCustomerToRoom Instance;
        public bool assigningCustomerToRoom = false;

        public GameObject AssignButton;

        private void Start()
        {
            Instance = this;
        }

        private void Update()
        {
            if(QueueControl.Instance.customersInQueue.Count >= 1)
            {
                AssignButton.SetActive(true);
            } else
            {
                AssignButton.SetActive(false);
            }
        }
        
        public void AssigningRoom()
        {
            assigningCustomerToRoom = true;
            ControlCamera.Instance.ShowLobby(false);
        }

        public void AssignToThisRoom(Room room)
        {
            if(assigningCustomerToRoom && QueueControl.Instance.currentCustomer != null)
            {
                if (room.customersInside.Count < room.roomType.Capacity)
                {
                    QueueControl.Instance.customersInQueue.Remove(QueueControl.Instance.currentCustomer);
                    room.customersInside.Add(QueueControl.Instance.currentCustomer.GetComponent<CustomerBehaviour>());

                    if(QueueControl.Instance.customersInQueue.Count == 0)
                    {
                        RoundControl.Instance.AllCustomersAssigned();
                    }
                }
            }
        }

        
    }
}

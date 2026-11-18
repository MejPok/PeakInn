using Assets.Code.Rooms;
using Assets.Code.Round;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Code.Customers
{
    public class CustomerBehaviour : MonoBehaviour
    {
        [SerializeReference]
        public CustomerNeed Needs;

        public int id = 0;
        public int roomId = -1;

        private void Start()
        {
            RoundControl.Instance.DayEndEvent += ReduceDaysStayed;
        }
        Room assignedRoom;
        public void GoToRoom(Room room)
        {
            roomId = room.roomId;
            assignedRoom = room;
            InRoom = true;
        }
        public bool InRoom = false;
        public Vector2 nextPoint;
        public float Speed;
        private void Update()
        {
            if (InRoom)
            {
                return;
            }
            Vector2 dir = nextPoint - (Vector2)transform.position;
            transform.position = new Vector2(transform.position.x + (dir.x * Speed * Time.deltaTime), transform.position.y + (dir.y * Speed * Time.deltaTime));
        }

        void ReduceDaysStayed()
        {
            Needs.StayForDays -= 1;
            if(Needs.StayForDays <= 0)
            {
                Destroy(gameObject);
            }
        }
        private void OnDestroy()
        {
            if (InRoom)
            {
                assignedRoom.customersInside.Remove(this);
                CustomerManager.Instance.customersHosted.Remove(this);
            }
        }


    }
}

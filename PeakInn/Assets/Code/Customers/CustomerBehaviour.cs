using Assets.Code.Rooms;
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

        public void GoToRoom(Room room)
        {
            roomId = room.roomId;
        }
    }
}

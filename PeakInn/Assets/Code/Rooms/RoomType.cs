using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Code.Rooms
{
    [CreateAssetMenu(menuName = "Room/Type")]
    public class RoomType : ScriptableObject
    {
        public GameObject prefab;
        public string Name;
        public int Capacity;
        public int Warmth;
        public int Cost;
        public int BaseCost;
    }
}

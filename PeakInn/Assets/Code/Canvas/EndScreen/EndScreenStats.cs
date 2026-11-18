using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace Assets.Code.Canvas.EndScreen
{
    class EndScreenStats : MonoBehaviour
    {
        public TextMeshProUGUI FoodConsumedPerDayText;
        public TextMeshProUGUI MoneyGainedPerDayText;
        public TextMeshProUGUI CapacityText;

        private void Update()
        {
            int consumedFood = 0;
            int moneyGained = 0;
            foreach(var room in RoomManager.Instance.createdRooms)
            {
                foreach(var customer in room.customersInside)
                {
                    consumedFood += customer.Needs.FoodRequiredPerNight;
                    moneyGained += customer.Needs.MoneyPerNight;
                    
                }
            }

            int currentCapacity = 0;
            int maxCapacity = 0;

            foreach(var room in RoomManager.Instance.createdRooms)
            {
                currentCapacity += room.customersInside.Count;
                maxCapacity += room.roomType.Capacity;    
            }

            FoodConsumedPerDayText.text = $"Peaches consumed today {consumedFood}";
            MoneyGainedPerDayText.text = $"Money gained today {moneyGained}";
            CapacityText.text = $"Inn capacity {currentCapacity} / {maxCapacity}";
        }

    }
}

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
            foreach(var customer in CustomerManager.Instance.customersHosted)
            {
                consumedFood += customer.Needs.FoodRequiredPerNight;
                moneyGained += customer.Needs.MoneyPerNight;
            }
            
        }

    }
}

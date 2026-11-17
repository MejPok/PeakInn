using Assets.Code.Player;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace Assets.Code.Canvas
{
    class ShowPlayerInfo : MonoBehaviour
    {
        public TextMeshProUGUI ReputationText;
        public TextMeshProUGUI MoneyText;
        public TextMeshProUGUI FoodText;

        private void Update()
        {
            ReputationText.text = $"Inn Reputation: {CustomerManager.Instance.Reputation}";
            MoneyText.text = $"Money: {PlayerMoney.Instance.Money}";
            FoodText.text = $"Peaches: {PlayerMoney.Instance.Peaches}";
        }

    }
}

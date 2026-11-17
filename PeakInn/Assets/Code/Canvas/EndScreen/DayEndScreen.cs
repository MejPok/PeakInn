using Assets.Code.Round;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Code.Canvas.EndScreen
{
    class DayEndScreen : MonoBehaviour
    {
        public GameObject endScreen;

        private void Start()
        {
            
        }

        public void DisplayScreen()
        {
            endScreen.SetActive(true);
        }

        public void GoIntoShop()
        {
            endScreen.SetActive(false);
            RoundControl.Instance.DayEnded();

        }
    }
}

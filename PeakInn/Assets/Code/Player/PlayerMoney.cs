using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Code.Player
{
    class PlayerMoney : MonoBehaviour
    {
        public static PlayerMoney Instance;
        public int Money = 300;
        public int Peaches = 10;

        private void Start()
        {
            Instance = this;
        }
    }
}

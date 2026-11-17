using Assets.Code.Round;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Code.Canvas
{
    class RoundCanvasControl : MonoBehaviour
    {
        public GameObject startDayButton;

        private void Update()
        {
            if(RoundControl.Instance.roundState == RoundState.WaitingForStart)
            {
                startDayButton.SetActive(true);
            } else
            {
                startDayButton.SetActive(false);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Code.Round
{
    class RoundControl : MonoBehaviour
    {
        public static RoundControl Instance;
        public RoundState roundState;

        public UnityAction StartDayEvent;
        public UnityAction DayEndEvent;
        public UnityAction ShoppingEvent;
        public UnityAction startDayEvent;



        private void Start()
        {
            Instance = this;
            roundState = RoundState.WaitingForStart;
        }

        public void StartDay()
        {
            Debug.Log("starting day");
            roundState = RoundState.AssigningCustomers;
            startDayEvent?.Invoke();
        }

        public void AllCustomersAssigned()
        {
            Debug.Log("day end");

            roundState = RoundState.DayEnd;
            DayEndEvent?.Invoke();
        }

        public void DayEnded()
        {
            Debug.Log("shopping");

            roundState = RoundState.Shopping;
            ShoppingEvent?.Invoke();
        }

        public void ShoppingEnd()
        {
            Debug.Log("shopping ended, waiting for start");

            roundState = RoundState.WaitingForStart;
        }
    }

    public enum RoundState
    {
        WaitingForStart,
        AssigningCustomers,
        DayEnd,
        Shopping
    }
}

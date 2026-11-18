using Assets.Code.Player;
using Assets.Code.Round;
using UnityEngine;

namespace Assets.Code.Canvas.EndScreen
{
    class DayEndScreen : MonoBehaviour
    {
        public GameObject endScreen;

        private void Start()
        {
            RoundControl.Instance.DayEndEvent += DisplayScreen;
        }

        public void DisplayScreen()
        {
            endScreen.SetActive(true);
            
            int consumedFood = 0;
            int moneyGained = 0;

            foreach (var room in RoomManager.Instance.createdRooms)
            {
                foreach (var customer in room.customersInside)
                {
                    consumedFood += customer.Needs.FoodRequiredPerNight;
                    moneyGained += customer.Needs.MoneyPerNight;
                }
            }

            PlayerMoney.Instance.Peaches -= consumedFood;

            if(PlayerMoney.Instance.Peaches <= 0)
            {
                CustomerManager.Instance.Reputation -= 10;
            }

            CustomerManager.Instance.Reputation += CustomerManager.Instance.customersHosted.Count;
        }

        public void GoIntoShop()
        {
            endScreen.SetActive(false);
            RoundControl.Instance.DayEnded();

        }
    }
}

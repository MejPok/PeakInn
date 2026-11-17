using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Code.Customers
{
    class ShowStats : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        TextMeshPro statText;
        CustomerBehaviour behaviour;

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.GetChild(0).gameObject.SetActive(false);

        }

        private void Start()
        {
            statText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();
            behaviour = GetComponent<CustomerBehaviour>();
        }

        private void Update()
        {
            statText.text = $"Warmth required: {behaviour.Needs.MinWarmthRequired} \n " +
                $"Staying for {behaviour.Needs.StayForDays} days \n " +
                $"Pays {behaviour.Needs.MoneyPerNight} per day \n " +
                $"Eats {behaviour.Needs.FoodRequiredPerNight} peaches per day";
        }
    }
}

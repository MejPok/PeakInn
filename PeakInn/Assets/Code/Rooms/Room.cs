using Assets.Code.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Code.Rooms
{
    public class Room : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public int roomId;
        public RoomType roomType;
        public int customersOccupying;
        public List<CustomerBehaviour> customersInside = new List<CustomerBehaviour>();
        public TextMeshPro occupiedText;
        public GameObject selectableOverlay;

        public void OnPointerEnter(PointerEventData eventData)
        {
            selectableOverlay.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            selectableOverlay.SetActive(false);

        }

        private void Update()
        {
            occupiedText.text = $"{customersInside.Count} / {roomType.Capacity}";
        }

    }
}

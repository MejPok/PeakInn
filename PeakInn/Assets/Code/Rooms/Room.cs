using Assets.Code.Customers;
using Assets.Code.Round;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Code.Rooms
{
    public class Room : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, IPointerClickHandler
    {
        public int roomId;
        public RoomType roomType;
        public int customersOccupying;
        public List<CustomerBehaviour> customersInside = new List<CustomerBehaviour>();
        public TextMeshPro occupiedText;
        public GameObject selectableOverlay;
        public List<Transform> customerPositions;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(RoundControl.Instance.roundState == RoundState.AssigningCustomers)
            {
                selectableOverlay.SetActive(true);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            selectableOverlay.SetActive(false);

        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (RoundControl.Instance.roundState == RoundState.AssigningCustomers)
            {
                selectableOverlay.SetActive(true);
            }
        }

        private void Update()
        {
            occupiedText.text = $"{customersInside.Count} / {roomType.Capacity}";

            for(int i = 0; i < customersInside.Count; i++)
            {
                customersInside[i].transform.position = customerPositions[i].position;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
             AssignCustomerToRoom.Instance.AssignToThisRoom(this);
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Code.Canvas
{
    class CameraDownUpControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public bool goUp;
        public bool moving;

        public void OnPointerEnter(PointerEventData eventData)
        {
            moving = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            moving = false;

        }

        private void Update()
        {
            if (moving)
            {
                if (goUp)
                {
                    Debug.Log("move up");
                    ControlCamera.Instance.yPositionDifference += Time.deltaTime;
                } else
                {
                    Debug.Log("move down");

                    ControlCamera.Instance.yPositionDifference -= Time.deltaTime;
                }
            }
        }
    }
}

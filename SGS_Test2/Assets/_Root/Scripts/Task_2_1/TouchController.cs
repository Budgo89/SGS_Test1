using System;
using Controllers;
using UnityEngine;

namespace Task_2_1
{
    public class TouchController : BaseController
    {
        public Action Touch;
        public void UpData()
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                    TouchAction();
            }
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                TouchAction();
            }
#endif
        }

        private void TouchAction()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Touch?.Invoke();
            }

        }
    }
}
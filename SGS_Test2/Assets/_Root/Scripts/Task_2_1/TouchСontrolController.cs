﻿using System;
using Controllers;
using UnityEngine;

namespace Task_2_1
{
    public class TouchController : BaseController, IСontrolController
    {
        public event EventHandler Touch;
        
        
        public void UpData()
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                    TouchAction();
            }
        }

        private void TouchAction()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Touch?.Invoke(this, EventArgs.Empty);
            }

        }
    }
}
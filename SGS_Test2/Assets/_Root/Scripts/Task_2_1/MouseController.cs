using System;
using Controllers;
using UnityEngine;

namespace Task_2_1
{
    public class MouseController : BaseController, IСontrolController
    {
        public event EventHandler Touch;
        
        
        public void UpData()
        {
            if (Input.GetMouseButtonDown(0))
            {
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
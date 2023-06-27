using System;
using Controllers;
using UnityEngine;
using View;
using Random = System.Random;

namespace Task_2_1
{
    public class ColorController : BaseController
    {
        private readonly TouchController _touchController;
        private Material _color;
        private Random _random;
        
        private Action _touchAction;
        public ColorController(TouchController touchController, CubeView cubeView)
        {
            _touchController = touchController;
            _color = cubeView.GetComponent<Renderer>().material;
            _random = new Random();
            _touchAction = _touchController.Touch += TouchAction;
        }

        private void TouchAction()
        {
            var red = _random.Next(0, 255)/255f;
            var green = _random.Next(0, 255)/255f;
            var blue = _random.Next(0, 255)/255f;
            
            var color = new Color(red, green, blue);
            _color.color = color;
        }
        
        private void DisposeControllers()
        {
            _touchAction = _touchController.Touch -= TouchAction;
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }
    }
}
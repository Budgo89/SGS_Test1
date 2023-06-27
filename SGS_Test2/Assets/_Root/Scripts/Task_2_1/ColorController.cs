using System;
using Controllers;
using UnityEngine;
using View;
using Random = System.Random;

namespace Task_2_1
{
    public class ColorController : BaseController
    {
        private readonly IСontrolController _touchСontrolController;
        private Material _color;
        private Random _random;
        
        private EventHandler _touchAction;
        
        
        public ColorController(IСontrolController touchСontrolController, CubeView cubeView)
        {
            _touchСontrolController = touchСontrolController;
            _color = cubeView.GetComponent<Renderer>().material;
            _random = new Random();
            _touchСontrolController.Touch += TouchСontrolAction;
        }

        private void TouchСontrolAction(object sender, EventArgs e)
        {
            var red = _random.Next(0, 255)/255f;
            var green = _random.Next(0, 255)/255f;
            var blue = _random.Next(0, 255)/255f;
            
            var color = new Color(red, green, blue);
            _color.color = color;
        }
        
        protected override void OnDispose()
        {
            _touchСontrolController.Touch -= TouchСontrolAction;
        }
    }
}
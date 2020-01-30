using System.Collections.Generic;
using System.Dynamic;
using Reunity.Core;
using UnityEngine;
using Reunity.Ui;
using System;

namespace Reunity.Javascript.Runtime.Bridges
{
    public class Ui : Connector
    {
        private readonly Transform Canvas;

        public Ui(Transform Canvas)
        {
            this.Canvas = Canvas;
        }

        [JsAction]
        public void Element(ExpandoObject obj)
        {
            Elements.Render(Canvas, obj);
        }
    }
}
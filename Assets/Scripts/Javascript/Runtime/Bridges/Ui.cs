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
        public void Text(ExpandoObject obj)
        {
            IDictionary<string, object> objectData = obj;

            TextElement textEl = new TextElement((string)objectData["value"]);

            textEl.ToGameObject(Canvas);
        }

        [JsAction]
        public void Button(ExpandoObject obj)
        {
            IDictionary<string, object> objectData = obj;

            Jint.Native.JsValue value = new Jint.Native.JsValue(false);

            var func = (Func<Jint.Native.JsValue, Jint.Native.JsValue[], Jint.Native.JsValue>)objectData["onClick"];

            Action<object> action = _ => func.Invoke(value, new Jint.Native.JsValue[0]);

            ButtonElement buttonEl = new ButtonElement((string)objectData["text"], action);

            buttonEl.ToGameObject(Canvas);
        }
    }
}
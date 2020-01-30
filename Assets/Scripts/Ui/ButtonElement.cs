using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ElementData = System.Collections.Generic.List<System.Collections.Generic.IDictionary<string, object>>;

namespace Reunity.Ui
{
    public class ButtonElement : Element
    {

        private struct Props
        {
            public ElementData Children;

            public Props(ElementData children)
            {
                Children = children;
            }
        }

        private Props ParseProps(IDictionary<string, object> propsDict)
        {
            ElementData children = new ElementData();

            if (propsDict.TryGetValue("children", out object childrenObject))
            {
                foreach (object child in (object[])childrenObject)
                {
                    IDictionary<string, object> childData = (IDictionary<string, object>)child;
                    children.Add((IDictionary<string, object>)child);
                }
            }

            return new Props(children);
        }

        public override GameObject Render(Transform parent, IDictionary<string, object> propsDict)
        {
            Props props = ParseProps(propsDict);

            GameObject buttonInstance = new GameObject("Button");
            buttonInstance.AddComponent<Button>();
            buttonInstance.AddComponent<RectTransform>();
            buttonInstance.AddComponent<Image>();
            buttonInstance.GetComponent<Transform>().SetParent(parent);
            buttonInstance.GetComponent<Transform>().localPosition = Vector3.zero;

            foreach (IDictionary<string, object> child in props.Children)
            {
                Elements.Render(buttonInstance.transform, child);
            }

            return buttonInstance;
        }
    }
}

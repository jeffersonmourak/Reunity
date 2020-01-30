using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Reunity.Ui
{
    public class TextElement : Element
    {

        private struct Props
        {
            public List<string> Children;

            public Props(List<string> children)
            {
                Children = children;
            }
        }

        private Props ParseProps(IDictionary<string, object> propsDict)
        {
            List<string> children = new List<string>();

            if (propsDict.TryGetValue("children", out object childrenObject)) {
                foreach(object child in (object[])childrenObject)
                {
                    children.Add((string)child);
                }
            }

            return new Props(children);
        }

        public override GameObject Render(Transform parent, IDictionary<string, object> propsDict)
        {
            Props props = ParseProps(propsDict);

            GameObject textInstance = new GameObject("Text");
            textInstance.AddComponent<Text>();

            textInstance.GetComponent<Text>().text = props.Children[0];
            textInstance.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            textInstance.GetComponent<Text>().color = new Color(0, 0, 0);

            textInstance.GetComponent<Transform>().SetParent(parent);
            textInstance.GetComponent<Transform>().localPosition = Vector3.zero;

            return textInstance;
        }
    }
}

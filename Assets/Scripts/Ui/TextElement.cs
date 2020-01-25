using UnityEngine;
using UnityEngine.UI;

namespace Reunity.Ui
{
    public class TextElement
    {
        private readonly string text;
        public TextElement(string text)
        {
            this.text = text;
        }

        public GameObject ToGameObject(Transform parent)
        {
            GameObject textInstance = new GameObject("Text");
            textInstance.AddComponent<Text>();

            textInstance.GetComponent<Text>().text = text;
            textInstance.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            textInstance.GetComponent<Text>().color = new Color(0, 0, 0);

            textInstance.GetComponent<Transform>().SetParent(parent);
            textInstance.GetComponent<Transform>().localPosition = Vector3.zero;

            return textInstance;
        }
    }
}

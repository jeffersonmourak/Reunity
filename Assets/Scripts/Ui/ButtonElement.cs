using System;
using UnityEngine;
using UnityEngine.UI;

namespace Reunity.Ui
{
    public class ButtonElement
    {
        private readonly string text;
        private Action<object> onClick;

        public ButtonElement(string text, Action<object> onClick)
        {
            this.text = text;
            this.onClick = onClick;
        }

        public GameObject ToGameObject(Transform parent)
        {
            TextElement textEl = new TextElement(text);

            GameObject buttonInstance = new GameObject("Button");
            buttonInstance.AddComponent<Button>();
            buttonInstance.AddComponent<RectTransform>();
            buttonInstance.AddComponent<Image>();

            buttonInstance.GetComponent<Button>().onClick.AddListener(() => onClick(null));

            buttonInstance.GetComponent<Transform>().SetParent(parent);
            buttonInstance.GetComponent<Transform>().localPosition = Vector3.zero;

            textEl.ToGameObject(buttonInstance.transform);

            return buttonInstance;
        }
    }
}

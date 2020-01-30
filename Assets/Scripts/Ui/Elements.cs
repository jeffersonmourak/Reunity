using System;
using System.Collections.Generic;
using UnityEngine;

namespace Reunity.Ui
{
    public static class Elements
    {
        public static Dictionary<string, Type> ElementsList { get; } = new Dictionary<string, Type>()
        {
            ["button"] = typeof(ButtonElement),
            ["text"] = typeof(TextElement),

        };

        public static void Render(Transform root, IDictionary<string, object> tree)
        {
            if (tree.TryGetValue("name", out object elementName))
            {
                string name = (string)elementName;

                if (ElementsList.TryGetValue(name, out Type type)) {
                    Element element = (Element)Activator.CreateInstance(type);

                    tree.TryGetValue("props", out object props);

                    element.Render(root, (IDictionary<string, object>)props);

                } else
                {
                    // TODO No element found.
                }
            }
        }
    }
}
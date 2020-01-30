using System;
using System.Collections.Generic;
using UnityEngine;

namespace Reunity.Ui
{
    public class Element
    {
        public virtual GameObject Render(Transform parent, IDictionary<string, object> props)
        {
            return null;
        }
    }
}
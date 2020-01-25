using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Reunity
{
    public sealed class Reunity
    {
        private static readonly Lazy<Reunity>
            lazy =
            new Lazy<Reunity>
                (() => new Reunity());

        public static Reunity Instance { get { return lazy.Value; } }
    }
}
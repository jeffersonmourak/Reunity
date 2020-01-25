using System;
using JSEngine = Jint.Engine;
using Reunity.Core;

namespace Reunity.Javascript
{
    public sealed class Engine
    {
        private static readonly Lazy<Engine>
            lazy = new Lazy<Engine> (() => new Engine());

        private static readonly JSEngine engine = new JSEngine();

        public static Engine Instance { get { return lazy.Value; } }

        public static void Execute(string script) {
            engine.Execute(script);
        }

        public static void AddValue(string name, object value)
        {
            engine.SetValue(name, value);
        }

        public static void AddValue(string name, Action<object> action)
        {
            engine.SetValue(name, action);
        }

        public static void SetBridge(BridgeInterceptor bridge)
        {
            engine.Invoke("BuildBridge", bridge);
        }

        public static void DestoryBridge(string bridgeName)
        {
            engine.Invoke("DestroyBridge", bridgeName);
        }
    }
}
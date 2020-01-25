using System.Collections.Generic;
using System.Reflection;
using Reunity.Javascript;

namespace Reunity.Core
{
    public class Connector
    {
        private readonly string BridgeName;
        public Connector()
        {
            BridgeName = GetType().Name;
            List<BridgeAction> actions = GetActionList();

            Engine.SetBridge(new BridgeInterceptor(BridgeName, actions));
        }

        private List<BridgeAction> GetActionList()
        {
            List<BridgeAction> actions = new List<BridgeAction>();

            foreach (MethodInfo method in GetType().GetMethods())
            {
                bool isAction = method.GetCustomAttribute(typeof(JsActionAttribute)) != null;
                if (isAction)
                {
                    
                    actions.Add(new BridgeAction(method.Name, (obj) => {
                        object[] arguments = new object[1] { obj };
                        method.Invoke(this, arguments);
                    }));
                }
            }

            return actions;
        }

        protected void DisconnectFromJs()
        {
            Engine.DestoryBridge(BridgeName);
        }
    }
}
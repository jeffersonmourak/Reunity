using System;
using System.Collections.Generic;

namespace Reunity.Core
{
    public struct BridgeInterceptor
    {
        public string name;
        public List<BridgeAction> actions;

        public BridgeInterceptor(string name, List<BridgeAction> actions)
        {
            this.name = name;
            this.actions = actions;
        }
    }

    public struct BridgeAction
    {
        public string name;
        public Action<object> action;

        public BridgeAction(string name, Action<object> action)
        {
            this.name = name;
            this.action = action;
        }
    }
}
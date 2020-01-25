using System.IO;
using UnityEngine;
using Reunity.Javascript;
using Reunity.Utils;
namespace Reunity
{

    public class Behaviour : MonoBehaviour
    {
        public TextAsset entry;

        private void Awake()
        {
            Engine.AddValue("log", Debug.Log);
            Engine.Execute(File.ReadAllText(Files.Javascript.Reunity));

            Javascript.Runtime.Bridges.Ui ui = new Javascript.Runtime.Bridges.Ui(transform);

            if (entry != null)
            {
                Engine.Execute(entry.ToString());
            }
        }
    }
}

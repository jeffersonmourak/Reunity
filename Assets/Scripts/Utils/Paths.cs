using System.IO;
using UnityEditor;

namespace Reunity.Utils
{
    public static class Paths
    {
        private static readonly string AssetGUID = AssetDatabase.FindAssets("l:ReunityScript", null)[0];
        private static readonly string AssetPath = AssetDatabase.GUIDToAssetPath(AssetGUID);

        public static readonly string Root = Path.GetFullPath(Path.GetDirectoryName(AssetPath));
        public static readonly string JSRuntime = Path.Combine(Root, "Javascript/Runtime");
    }
}

using UnityEditor;
using UnityEngine;

namespace DividerHierarchyExtension
{
    internal static class HierarchyExtension
    {
        public static GameObject selected;

        [MenuItem("GameObject/Make Divider", false, 0)]
        private static void Edit()
        {
            GameObject gameObject = Selection.activeGameObject;

            if (gameObject == null)
                return;

            selected = gameObject;

            const int width = 250;
            const int height = 100;

            var window = ScriptableObject.CreateInstance<MakeDividerWindow>();
            window.position = new Rect(Screen.currentResolution.width / 2f - width / 2f, Screen.currentResolution.height / 2f - height / 2f, width, height);
            window.Show();
        }
    }
}
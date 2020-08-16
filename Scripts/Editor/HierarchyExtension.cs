using UnityEditor;
using UnityEngine;

namespace DividerHierarchyExtension
{
    internal static class HierarchyExtension
    {
        public const string Prefix = "----- ";
        public const string Suffix = " -----";

        [MenuItem("GameObject/Create or Edit Divider", false, 0)]
        private static void HandleDivider()
        {
            bool shouldCreateDivider = Selection.activeGameObject == null;
            
            ShowWindow(shouldCreateDivider ? "Create Divider" : "Edit Divider", Selection.activeGameObject);
        }

        private static void ShowWindow(string title, GameObject selectedGameObject)
        {
            var window = (MakeDividerWindow)EditorWindow.GetWindow(typeof(MakeDividerWindow), true, title);
            window.Initialize(selectedGameObject);
            window.Show();
        }
    }
}
using UnityEditor;
using UnityEngine;

namespace DividerHierarchyExtension
{
    internal static class HierarchyExtension
    {
        public static GameObject SelectedGameObject { get; private set; }
        
        [MenuItem("GameObject/Create or Edit Divider", false, 0)]
        private static void HandleDivider()
        {
            SelectedGameObject = Selection.activeGameObject;

            bool shouldCreateDivider = SelectedGameObject == null;
            
            ShowWindow(shouldCreateDivider ? "Create Divider" : "Edit Divider", SelectedGameObject);
        }

        private static void ShowWindow(string title, GameObject selectedGameObject)
        {
            var window = (MakeDividerWindow)EditorWindow.GetWindow(typeof(MakeDividerWindow), true, title);
            window.Initialize(selectedGameObject);
            window.Show();
        }
    }
}
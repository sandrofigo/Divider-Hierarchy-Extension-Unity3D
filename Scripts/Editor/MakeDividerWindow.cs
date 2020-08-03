using UnityEditor;
using UnityEngine;

namespace DividerHierarchyExtension
{
    internal class MakeDividerWindow : EditorWindow
    {
        private bool positionSet;

        private bool focused;

        private void OnGUI()
        {
            GameObject selected = HierarchyExtension.selected;

            Event e = Event.current;

            EditorGUILayout.LabelField("Enter the name of the divider:", EditorStyles.wordWrappedLabel);

            GUI.SetNextControlName("textfield");

            string before = RemoveDecoration(selected.name);
            string after = EditorGUILayout.TextField(before);

            if (before != after)
                SetSelectionDirty();

            selected.name = AddDecoration(after);

            GUILayout.Space(EditorGUIUtility.singleLineHeight);

            if (!focused)
            {
                EditorGUI.FocusTextInControl("textfield");
                focused = true;
            }

            if (GUILayout.Button("OK") || e.isKey && e.keyCode == KeyCode.Return)
            {
                Close();
            }
        }

        private string RemoveDecoration(string s)
        {
            s = s.Replace("----- ", string.Empty);
            s = s.Replace(" -----", string.Empty);

            return s;
        }

        private string AddDecoration(string s)
        {
            return $"----- {s} -----";
        }

        private void OnDestroy()
        {
            SetSelectionDirty();
        }

        private void SetSelectionDirty()
        {
            EditorUtility.SetDirty(HierarchyExtension.selected);
        }
    }
}
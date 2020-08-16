using UnityEditor;
using UnityEngine;

namespace DividerHierarchyExtension
{
    internal class MakeDividerWindow : EditorWindow
    {
        private const int Width = 250;
        private const int Height = 100;

        private const string TextFieldName = "textField";
        
        private bool positionSet;
        
        private bool focused;
        
        private GameObject selectedGameObject;

        private string initialName;
        private string nameField;

        private bool HasNameChanged => nameField != initialName;
        
        public void Initialize(GameObject selected)
        {
            position = new Rect(Screen.currentResolution.width / 2f - Width / 2f, Screen.currentResolution.height / 2f - Height / 2f, Width, Height);
            
            selectedGameObject = selected;

            if (selectedGameObject != null)
                initialName = nameField = RemoveDecoration(selectedGameObject.name);
        }
        
        private void OnGUI()
        {
            Event e = Event.current;

            EditorGUILayout.LabelField("Enter the name of the divider:", EditorStyles.wordWrappedLabel);

            GUI.SetNextControlName(TextFieldName);
            
            nameField = EditorGUILayout.TextField(nameField);

            GUILayout.Space(EditorGUIUtility.singleLineHeight);

            HandleNameTextFieldFocus();

            if (GUILayout.Button("OK") || e.isKey && e.keyCode == KeyCode.Return)
            {
                if (HasNameChanged)
                {
                    if (selectedGameObject == null)
                        selectedGameObject = new GameObject();

                    SetSelectionDirty();
                    ApplyName();
                }

                Close();
            }
        }

        private void HandleNameTextFieldFocus()
        {
            if (focused)
                return;
            
            EditorGUI.FocusTextInControl(TextFieldName);
            
            focused = true;
        }

        private void ApplyName()
        {
            selectedGameObject.name = AddDecoration(nameField);
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
            EditorUtility.SetDirty(selectedGameObject);
        }
    }
}
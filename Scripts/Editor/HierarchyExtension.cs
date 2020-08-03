using UnityEditor;
using UnityEngine;

public class HierarchyExtension
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

public class MakeDividerWindow : EditorWindow
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
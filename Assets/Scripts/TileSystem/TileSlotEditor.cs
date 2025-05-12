using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileSlot)), CanEditMultipleObjects]
public class TileSlotEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        base.OnInspectorGUI();

        float buttonWidth = (EditorGUIUtility.currentViewWidth - 25) / 2;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Field", GUILayout.Width(buttonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().field;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }
        
        if (GUILayout.Button("Road", GUILayout.Width(buttonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().road;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Sideway", GUILayout.Width(buttonWidth * 2)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().sideway;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        GUILayout.EndHorizontal();
    }
}

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileSlot)), CanEditMultipleObjects]
public class TileSlotEditor : Editor
{

    private GUIStyle centeredStyle;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        base.OnInspectorGUI();

        centeredStyle = new GUIStyle(GUI.skin.label)
        {
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold,
            fontSize = 16,
        };

        float oneButtonWidth = (EditorGUIUtility.currentViewWidth - 25);
        float twoButtonWidth = (EditorGUIUtility.currentViewWidth - 25) / 2;
        float threeButtonWidth = (EditorGUIUtility.currentViewWidth - 25) / 3;

        GUILayout.Label("Position and Rotation", centeredStyle);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Rotate Left", GUILayout.Width(twoButtonWidth)))
        {
            foreach (var item in targets)
            {
                ((TileSlot)item).RotateTile(-1);
            }
        }

        if (GUILayout.Button("Rotate Right", GUILayout.Width(twoButtonWidth)))
        {
            foreach (var item in targets)
            {
                ((TileSlot)item).RotateTile(1);
            }
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Up", GUILayout.Width(twoButtonWidth)))
        {
            foreach (var item in targets)
            {
                ((TileSlot)item).AdjustHigh(1);
            }
        }

        if (GUILayout.Button("Down", GUILayout.Width(twoButtonWidth)))
        {
            foreach (var item in targets)
            {
                ((TileSlot)item).AdjustHigh(-1);
            }
        }

        GUILayout.EndHorizontal();

        GUILayout.Label("Tile Options", centeredStyle);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Field", GUILayout.Width(twoButtonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().field;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        if (GUILayout.Button("Road", GUILayout.Width(twoButtonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().road;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Sideway", GUILayout.Width(oneButtonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().sideway;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        GUILayout.EndHorizontal();

        GUILayout.Label("Corner Options", centeredStyle);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Inner Corner", GUILayout.Width(twoButtonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().innerCorner;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        if (GUILayout.Button("Outer Corner", GUILayout.Width(twoButtonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().outerCorner;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        GUILayout.EndHorizontal();

        GUILayout.Label("Hill Options", centeredStyle);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Upper Hill", GUILayout.Width(threeButtonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().upperHill;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        if (GUILayout.Button("Middle Hill", GUILayout.Width(threeButtonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().middleHill;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        if (GUILayout.Button("Lower Hill", GUILayout.Width(threeButtonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().lowerHill;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        GUILayout.EndHorizontal();

        GUILayout.Label("Bridge Options", centeredStyle);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Bridge Field", GUILayout.Width(twoButtonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().bridgeField;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        if (GUILayout.Button("Bridge Road", GUILayout.Width(twoButtonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().bridgeRoad;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Bridge Sideway", GUILayout.Width(oneButtonWidth)))
        {
            GameObject newTile = FindFirstObjectByType<TileHolder>().bridgeSideway;

            foreach (var item in targets)
            {
                ((TileSlot)item).SwitchTitle(newTile);
            }
        }

        GUILayout.EndHorizontal();
    }

}

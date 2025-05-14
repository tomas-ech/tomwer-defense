using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuilder : MonoBehaviour
{
    [SerializeField] private GameObject mainPrefab;

    [SerializeField] private int gridLength = 10;
    [SerializeField] private int gridWidth = 10;

    private List<GameObject> createdTile;

    [ContextMenu("Build Grid")]
    private void BuildGrid()
    {
        createdTile = new();

        for (int i = 0; i < gridLength; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                CreateTile(i, j);
            }
        }
    }

    [ContextMenu("Clear Grid")]
    private void ClearGrid()
    {
        foreach (var item in createdTile)
        {
            DestroyImmediate(item);
        }

        createdTile.Clear();
    }

    private void CreateTile(float xPosition, float zPosition)
    {
        Vector3 newPosition = new(xPosition, 0, zPosition);
        GameObject newTile = Instantiate(mainPrefab, newPosition, Quaternion.identity, transform);

        createdTile.Add(newTile);
    }
}

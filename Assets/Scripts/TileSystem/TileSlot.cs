using System.Collections.Generic;
using UnityEngine;

public class TileSlot : MonoBehaviour
{
    private MeshRenderer meshRenderer => GetComponent<MeshRenderer>();
    private MeshFilter meshFilter => GetComponent<MeshFilter>();

    public void SwitchTitle(GameObject tileReference)
    {
        TileSlot newTile = tileReference.GetComponent<TileSlot>();

        meshFilter.mesh = newTile.GetMesh();
        meshRenderer.material = newTile.GetMaterial();

        foreach (GameObject item in GetAllChildren())
        {
            DestroyImmediate(item);
        }

        foreach (GameObject item in newTile.GetAllChildren())
        {
            Debug.Log("Creado");
            Instantiate(item, transform);
        }
    }

    public Material GetMaterial() => meshRenderer.sharedMaterial;
    public Mesh GetMesh() => meshFilter.sharedMesh;

    public List<GameObject> GetAllChildren()
    {
        List<GameObject> children = new();

        foreach (Transform item in transform)
        {
            children.Add(item.gameObject);
        }

        return children;
    }
}

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileSlot : MonoBehaviour
{
    private MeshRenderer meshRenderer => GetComponent<MeshRenderer>();
    private MeshFilter meshFilter => GetComponent<MeshFilter>();
    private Collider myCollider => GetComponent<Collider>();

    public void SwitchTitle(GameObject tileReference)
    {
        gameObject.name = tileReference.name;

        TileSlot newTile = tileReference.GetComponent<TileSlot>();

        meshFilter.mesh = newTile.GetMesh();
        meshRenderer.material = newTile.GetMaterial();

        UpdateCollider(newTile.GetCollider());

        foreach (GameObject item in GetAllChildren())
        {
            DestroyImmediate(item);
        }

        foreach (GameObject item in newTile.GetAllChildren())
        {
            Instantiate(item, transform);
        }
    }

    public Material GetMaterial() => meshRenderer.sharedMaterial;
    public Mesh GetMesh() => meshFilter.sharedMesh;
    public Collider GetCollider() => myCollider;

    public List<GameObject> GetAllChildren()
    {
        List<GameObject> children = new();

        foreach (Transform item in transform)
        {
            children.Add(item.gameObject);
        }

        return children;
    }

    public void UpdateCollider(Collider newCollider)
    {
        DestroyImmediate(myCollider);

        if (newCollider is BoxCollider)
        {
            BoxCollider original = newCollider.GetComponent<BoxCollider>();
            BoxCollider newBoxCollider = transform.AddComponent<BoxCollider>();

            newBoxCollider.center = original.center;
            newBoxCollider.size = original.size;
        }

        if (newCollider is MeshCollider)
        {
            MeshCollider original = newCollider.GetComponent<MeshCollider>();
            MeshCollider newMeshCollider = transform.AddComponent<MeshCollider>();

            newMeshCollider.sharedMesh = original.sharedMesh;
            newMeshCollider.convex = original.convex;
        }
    }
}

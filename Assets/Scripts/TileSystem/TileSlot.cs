using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class TileSlot : MonoBehaviour
{
    private MeshRenderer meshRenderer => GetComponent<MeshRenderer>();
    private MeshFilter meshFilter => GetComponent<MeshFilter>();
    private Collider myCollider => GetComponent<Collider>();
    private NavMeshSurface myNavMesh => GetComponentInParent<NavMeshSurface>();

    public void SwitchTitle(GameObject tileReference)
    {
        gameObject.name = tileReference.name;

        TileSlot newTile = tileReference.GetComponent<TileSlot>();

        meshFilter.mesh = newTile.GetMesh();
        meshRenderer.material = newTile.GetMaterial();

        UpdateCollider(newTile.GetCollider());
        UpdateChildren(newTile);
        UpdateLayer(tileReference);
        UpdateNavMesh();
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

    private void UpdateNavMesh() => myNavMesh.BuildNavMesh();

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

    private void UpdateChildren(TileSlot newTile)
    {
        foreach (GameObject item in GetAllChildren())
        {
            DestroyImmediate(item);
        }

        foreach (GameObject item in newTile.GetAllChildren())
        {
            Instantiate(item, transform);
        }
    }

    public void UpdateLayer(GameObject reference) => gameObject.layer = reference.layer;

    public void RotateTile(int direction)
    {
        transform.Rotate(0, 90 * direction, 0);
        UpdateNavMesh();
    }
    public void AdjustHigh(int direction)
    {
        UpdateNavMesh();
        transform.position += new Vector3(0, 0.1f * direction, 0);
    }
}

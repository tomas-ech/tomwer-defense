using UnityEngine;

public class TileHolder : MonoBehaviour
{
    public GameObject road;
    public GameObject field;
    public GameObject sideway;

    [Header("Corners")]
    public GameObject innerCorner;
    public GameObject smallInnerCorner;
    public GameObject outerCorner;
    public GameObject smallOuterCorner;

    [Header("Hills")]
    public GameObject upperHill;
    public GameObject middleHill;
    public GameObject lowerHill;

    [Header("Bridges")]
    public GameObject bridgeField;
    public GameObject bridgeRoad;
    public GameObject bridgeSideway;
}

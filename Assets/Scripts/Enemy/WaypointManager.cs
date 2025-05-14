using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    public Transform[] GetWaypoints => waypoints;
}

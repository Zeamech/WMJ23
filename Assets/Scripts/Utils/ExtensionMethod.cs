using UnityEngine;
using static Map;

public static class ExtensionMethod
{
    public static Enemy Instantiate(Object original, Vector3 position, EnemySO Template)
    {
        GameObject enemy = Object.Instantiate(original, position, Quaternion.identity) as GameObject;

        Enemy e = enemy.transform.GetComponent<Enemy>();
        e.Template = Template;
        return e;
    }

    public static Map Instantiate(Object mapPrefab, GameObject mapLocationPrefab)
    {
        GameObject Map = Object.Instantiate(mapPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        Map map = Map.transform.GetComponent<Map>();
        map.MapLocationPrefab = mapLocationPrefab;
        return map;
    }

    public static MapLocation Instantiate(Object mapLocationPrefab, LocationType location, Vector3 pos, Transform parent)
    {
        GameObject MapLocation = Object.Instantiate(mapLocationPrefab, pos, Quaternion.identity, parent) as GameObject;
        MapLocation loc = MapLocation.transform.GetComponent<MapLocation>();
        loc.Location = location;
        return loc;
    }
}
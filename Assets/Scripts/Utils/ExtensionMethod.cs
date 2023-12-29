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

    public static Map Instantiate(Object mapPrefab, GameObject mapLocationPrefab, GameObject mapArrowPrefab)
    {
        GameObject Map = Object.Instantiate(mapPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        Map map = Map.transform.GetComponent<Map>();
        map.MapLocationPrefab = mapLocationPrefab;
        map.MapArrowPrefab = mapArrowPrefab;
        return map;
    }

    public static MapLocation Instantiate(Object mapLocationPrefab, LocationType location, Vector3 pos, Transform parent)
    {
        GameObject MapLocation = Object.Instantiate(mapLocationPrefab, pos, Quaternion.identity, parent) as GameObject;
        MapLocation loc = MapLocation.transform.GetComponent<MapLocation>();
        loc.Location = location;
        return loc;
    }

    public static GameObject Instantiate(Object mapArrowPrefab, Vector3 pos, Transform parent, ArrowDirection dir)
    {
        GameObject arrow = Object.Instantiate(mapArrowPrefab, pos, Quaternion.identity, parent) as GameObject;
        arrow.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(dir.ToString());
        return arrow;
    }
}
using System.Collections.Generic;
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

    public static AllyCard Instantiate(Object allyCardPrefab, int index, Transform parent, Ally ally)
	{
        Vector3 pos = Vector3.right * 2f;
        pos.y = -1.28125f * 2 * (index - 1);
        GameObject allyCardGo = Object.Instantiate(allyCardPrefab, pos, Quaternion.identity, parent) as GameObject;
        AllyCard allyCard = allyCardGo.GetComponent<AllyCard>();
        allyCard.Ally = ally;
        return allyCard;
	}

    public static Battle Instantiate(Object battleFieldPrefab, List<Ally> party)
	{
        GameObject BattleGO = Object.Instantiate(battleFieldPrefab) as GameObject;
        Battle battle = BattleGO.GetComponent<Battle>();  
        battle.Party = party;
        return battle;
	}
}
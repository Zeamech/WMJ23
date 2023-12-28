
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer BGSpriteRenderer;
    public List<List<LocationType>> MapLocations;
    public void Start()
	{
        BGSpriteRenderer = GetComponent<SpriteRenderer>();
        MapLocations = new List<List<LocationType>>();

        // Start with a guaranteed creature encounter
        List<LocationType> firstLayer = new List<LocationType>();
        firstLayer.Add(LocationType.Creature);
        firstLayer.Add(LocationType.Creature);
        MapLocations.Add(firstLayer);

        // Add 20 random layers
        for (int i = 0; i < 20; i++)
        {
            // Generate 1 to 3 random locations
            List<LocationType> layer = new List<LocationType>();
            int r = Random.Range(1, 4);
            for (int j = 0; j < r; j++) layer.Add((LocationType)Random.Range(0, (int)LocationType.NumberOfLocationTypes));
            MapLocations.Add(layer);
        }

        // End with a final boss
        List<LocationType> finalLayer = new List<LocationType>();
        finalLayer.Add(LocationType.FinalBoss);
        MapLocations.Add(finalLayer);
    }

    public enum LocationType
    {
        Creature,
        Battle,
        Treasure,
        Shop,
        FinalBoss,
        NumberOfLocationTypes
    }
}


using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public float YSpacing;
    public float XSpacing;
    [HideInInspector] public GameObject MapLocationPrefab;
    [HideInInspector] public SpriteRenderer BGSpriteRenderer;
    [HideInInspector] public List<List<LocationType>> MapLocationTypes;
    [HideInInspector] public List<List<MapLocation>> MapLocations;
    public void Start()
	{
        BGSpriteRenderer = GetComponent<SpriteRenderer>();
        MapLocationTypes = new List<List<LocationType>>();
        MapLocations = new List<List<MapLocation>>();

        // Start with a guaranteed creature encounter
        List<LocationType> firstLayer = new List<LocationType>();
        firstLayer.Add(LocationType.Creature);
        firstLayer.Add(LocationType.Creature);
        MapLocationTypes.Add(firstLayer);

        // Add 20 random layers
        for (int i = 0; i < 20; i++)
        {
            // Generate 1 to 3 random locations
            List<LocationType> layer = new List<LocationType>();
            int r = Random.Range(1, 4);
            for (int j = 0; j < r; j++) layer.Add((LocationType)Random.Range(0, (int)LocationType.NumberOfLocationTypes));
            MapLocationTypes.Add(layer);
        }

        // End with a final boss
        List<LocationType> finalLayer = new List<LocationType>();
        finalLayer.Add(LocationType.FinalBoss);
        MapLocationTypes.Add(finalLayer);

        // Instantiate a bunch of child prefabs for every map location, assign sprite based on Type, location based on position in list, arrows based on position in list.
        int layerIndex = 0;
        foreach (List<LocationType> layer in MapLocationTypes)
		{
            List<MapLocation> mapLayer = new List<MapLocation>();
            if(layer.Count == 1)
			{
                Vector3 pos = new Vector3(0, layerIndex * YSpacing, 0);
                mapLayer.Add(ExtensionMethod.Instantiate(MapLocationPrefab, layer[0], pos, transform));
			}
            else if(layer.Count == 2)
			{
                Vector3 pos = new Vector3((XSpacing/2.0f)*-1, layerIndex * YSpacing, 0);
                mapLayer.Add(ExtensionMethod.Instantiate(MapLocationPrefab, layer[0], pos, transform));
                pos = new Vector3(XSpacing / 2.0f, layerIndex * YSpacing, 0);
                mapLayer.Add(ExtensionMethod.Instantiate(MapLocationPrefab, layer[1], pos, transform));
            }
            else if(layer.Count == 3)
			{
                Vector3 pos = new Vector3(XSpacing * -1, layerIndex * YSpacing, 0);
                mapLayer.Add(ExtensionMethod.Instantiate(MapLocationPrefab, layer[0], pos, transform));
                pos = new Vector3(0, layerIndex * YSpacing, 0);
                mapLayer.Add(ExtensionMethod.Instantiate(MapLocationPrefab, layer[1], pos, transform));
                pos = new Vector3(XSpacing, layerIndex * YSpacing, 0);
                mapLayer.Add(ExtensionMethod.Instantiate(MapLocationPrefab, layer[2], pos, transform));
            }
            MapLocations.Add(mapLayer);
            layerIndex++;
		}

        // Enable the BoxColliders (clickable locations) for the current layer
        foreach(MapLocation mapLocation in MapLocations[0]) mapLocation.BoxCollider.enabled = true;

        // Set up all of the LineRenderers. 
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

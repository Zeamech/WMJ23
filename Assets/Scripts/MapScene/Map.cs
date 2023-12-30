
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public float YSpacing;
    public float XSpacing;
    [HideInInspector] public GameObject MapLocationPrefab;
    [HideInInspector] public GameObject MapArrowPrefab;
    [HideInInspector] public SpriteRenderer BGSpriteRenderer;
    [HideInInspector] public List<List<LocationType>> MapLocationTypes;
    [HideInInspector] public List<List<MapLocation>> MapLocations;
    private BoxCollider2D viewPartyButton;
    private Camera mainCamera;
    public void Start()
	{
        viewPartyButton = GameObject.Find("View Party").GetComponent<BoxCollider2D>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        BGSpriteRenderer = GetComponent<SpriteRenderer>();
        MapLocationTypes = new List<List<LocationType>>();
        MapLocations = new List<List<MapLocation>>();

        // Start with a guaranteed creature encounter
        List<LocationType> firstLayer = new List<LocationType>();
        firstLayer.Add(LocationType.Creature);
        firstLayer.Add(LocationType.Creature);
        MapLocationTypes.Add(firstLayer);

        // Add 19 random layers
        for (int i = 0; i < 19; i++)
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

        // Set up all of the arrows. 
        layerIndex = 0;
        float arrowYOffset = YSpacing / -2f;
        foreach (List<MapLocation> layer in MapLocations)
		{

            if(layerIndex == 0) // Starting point
			{
                Vector3 pos = new Vector3(layer[0].transform.position.x, layer[0].transform.position.y + arrowYOffset, 0);
                ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.right * 0.75f, transform, ArrowDirection.Left); // Left
                pos = new Vector3(layer[1].transform.position.x, layer[1].transform.position.y + arrowYOffset, 0);
                ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.left * 0.75f, transform, ArrowDirection.Right); // Right
            }
			else // Draw arrows from previous layer
			{
                int xIndex = 0;
                foreach(MapLocation mapLocation in layer)
				{
                    Vector3 pos = new Vector3(mapLocation.transform.position.x, mapLocation.transform.position.y + arrowYOffset, 0);
                    switch (MapLocations[layerIndex - 1].Count)
                    {
                        case 1:
                            if (layer.Count == 1) // Draw one up arrow
							{
                                ExtensionMethod.Instantiate(MapArrowPrefab, pos, transform, ArrowDirection.Up);
							}
                            else if (layer.Count == 2) // Left or right
							{
                                if(xIndex == 0) ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.right, transform, ArrowDirection.Left); // Left
                                else if(xIndex == 1) ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.left, transform, ArrowDirection.Right); // Right
                            }
                            else if (layer.Count == 3) // Left, up, or right
							{
                                if (xIndex == 0) ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.right, transform, ArrowDirection.Left); // Left
                                else if (xIndex == 1) ExtensionMethod.Instantiate(MapArrowPrefab, pos, transform, ArrowDirection.Up); // Up
                                else if (xIndex == 2) ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.left
                                    , transform, ArrowDirection.Right); // Right
                            }
                            break;
                        case 2:
                            if (layer.Count == 1) // 2 to 1: Draw a right and left arrow
                            {
                                ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.left, transform, ArrowDirection.Right);
                                ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.right, transform, ArrowDirection.Left);
                            }
                            else if (layer.Count == 2) // 2 to 2: Up & Right, or Up & Left
                            {
                                if (xIndex == 0)
                                {
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.right * 0.75f, transform, ArrowDirection.Right);
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos, transform, ArrowDirection.Up);
                                } 
                                else if (xIndex == 1)
								{
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.left * 0.75f, transform, ArrowDirection.Left);
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos, transform, ArrowDirection.Up);
                                }
                            }
                            else if (layer.Count == 3) // 2 to 3: Left, Right & Left, or Right
							{
                                if (xIndex == 0)
                                {
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.right, transform, ArrowDirection.Left);
                                }
                                else if (xIndex == 1)
                                {
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.left, transform, ArrowDirection.Right);
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.right, transform, ArrowDirection.Left);
                                }
                                else if (xIndex == 2)
								{
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.left, transform, ArrowDirection.Right);
                                }
                            }
                            break;
                        case 3:
                            if (layer.Count == 1) // 3 to 1: Right & Up & Left
                            {
                                ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.left * 1.25f, transform, ArrowDirection.Right);
                                ExtensionMethod.Instantiate(MapArrowPrefab, pos, transform, ArrowDirection.Up);
                                ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.right * 1.25f, transform, ArrowDirection.Left);
                            }
                            else if (layer.Count == 2) // 3 to 2: Right & Left
                            {
                                ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.left, transform, ArrowDirection.Right);
                                ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.right, transform, ArrowDirection.Left);
                            }
                            else if (layer.Count == 3) // 3 to 3: Up & Left, Right & Up & Left, or Up & Right
                            {
                                if (xIndex == 0)
                                {
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos, transform, ArrowDirection.Up);
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.right * 1.25f, transform, ArrowDirection.Left);
                                }
                                else if (xIndex == 1)
                                {
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.left * 1.25f, transform, ArrowDirection.Right);
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos, transform, ArrowDirection.Up);
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.right * 1.25f, transform, ArrowDirection.Left);
                                }
                                else if (xIndex == 2)
                                {
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos, transform, ArrowDirection.Up);
                                    ExtensionMethod.Instantiate(MapArrowPrefab, pos + Vector3.left * 1.25f, transform, ArrowDirection.Right);
                                }
                            }
                            break;
                    }
                    xIndex++;

                }
			}
            layerIndex++;
		}
    }

	public void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if(viewPartyButton.OverlapPoint(worldPos))
			{

			}

        }
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

    public enum ArrowDirection
    {
        Left,
        Right,
        Up
    }
}


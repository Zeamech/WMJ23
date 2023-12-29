using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Map;

public class MapLocation : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer SpriteRenderer;
    [HideInInspector] public LocationType Location;
    [HideInInspector] public BoxCollider2D BoxCollider;

	private void Awake()
	{
		SpriteRenderer = GetComponent<SpriteRenderer>();
		BoxCollider = GetComponent<BoxCollider2D>();
		BoxCollider.enabled = false;
	}

	void Start()
    {
		// Set the icon depending on the location type
		switch (Location)
		{
			case LocationType.Creature: break;
			case LocationType.Battle: break;
			case LocationType.Treasure: break;
			case LocationType.Shop: break;
			case LocationType.FinalBoss: break;
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnMouseEnter()
	{
		Color color = Color.black;
		color.a = 0.2f;
		SpriteRenderer.material.color = color;
	}

	private void OnMouseExit()
	{
		SpriteRenderer.material.color = Color.white;
	}

	private void OnMouseDown()
	{
		switch(Location)
		{
			case LocationType.Creature: break;
			case LocationType.Battle: break;
			case LocationType.Treasure: break;
			case LocationType.Shop: break;
			case LocationType.FinalBoss: break;
		}
	}
}

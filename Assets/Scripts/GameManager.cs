using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<List<LocationType>> Map;
    public List<Ally> Party;
    //public List<CharmSong> Melodies;
    public int Gold;

    // Start is called before the first frame update
    void Start()
    {
        Party = new List<Ally>();
        Gold = 20;

        // Generate Graph
        Map = new List<List<LocationType>>();

        //Start with a guaranteed creature encounter
        List<LocationType> firstLayer = new List<LocationType>();
        firstLayer.Add(LocationType.Creature);
        firstLayer.Add(LocationType.Creature);

        // Add 20 random layers
        for (int i = 0; i < 20; i++)
		{
            // Generate 1 to 3 random locations
            List<LocationType> layer = new List<LocationType>();
            int r = Random.Range(1, 4);
            for(int j = 0; j < r; j++) layer.Add((LocationType)Random.Range(0,(int)LocationType.NumberOfLocationTypes));
            Map.Add(layer);
		}

        // End with a final boss
        List<LocationType> finalLayer = new List<LocationType>();
        finalLayer.Add(LocationType.FinalBoss);
    }

    // Update is called once per frame
    void Update()
    {
        
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

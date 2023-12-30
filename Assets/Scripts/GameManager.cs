using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MapPrefab;
    public GameObject MapLocationPrefab;

    [HideInInspector] public Map Map;
    public List<AllySO> Party;
    //[HideInInspector] public List<CharmSong> Melodies;
    [HideInInspector] public int Gold;
    [HideInInspector] public int CurrentLayer;

    private void Awake()
    {
        if (MapPrefab = null) { MapPrefab = null; }
        if(MapLocationPrefab = null) { MapLocationPrefab = null; }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(AllySO ally in Party)
        {
            ally.Owned = true;
        }
        Party = new List<AllySO>();
        Gold = 20;
        CurrentLayer = 0;

        // Generate Map
        if(MapPrefab || MapLocationPrefab != null)
        {
            Map = ExtensionMethod.Instantiate(MapPrefab, MapLocationPrefab);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

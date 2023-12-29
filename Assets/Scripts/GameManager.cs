using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MapPrefab;
    public GameObject MapLocationPrefab;

    [HideInInspector] public Map Map;
    [HideInInspector] public List<Ally> Party;
    //[HideInInspector] public List<CharmSong> Melodies;
    [HideInInspector] public int Gold;
    [HideInInspector] public int CurrentLayer;

    // Start is called before the first frame update
    void Start()
    {
        Party = new List<Ally>();
        Gold = 20;
        CurrentLayer = 0;

        // Generate Map
        Map = ExtensionMethod.Instantiate(MapPrefab, MapLocationPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MapPrefab;
    [HideInInspector] public Map Map;
    [HideInInspector] public List<Ally> Party;
    //[HideInInspector] public List<CharmSong> Melodies;
    [HideInInspector] public int Gold;

    // Start is called before the first frame update
    void Start()
    {
        Party = new List<Ally>();
        Gold = 20;

        // Generate Map
        GameObject MapGO = Instantiate(MapPrefab, transform.position, Quaternion.identity);
        Map = MapGO.GetComponent<Map>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

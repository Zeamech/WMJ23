using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> CreaturePrefabs;

    [SerializeField]
    public GameObject BattleFieldPrefab;

    public GameObject MapPrefab;
    public GameObject MapLocationPrefab;
    public GameObject MapArrowPrefab;
    public TextMeshPro CoinText;

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

        if(SceneManager.GetActiveScene().name == "Minigame")
        {
            Debug.Log("Minigame Started");
        }
        else if (SceneManager.GetActiveScene().name == "Battle")
        {
            Debug.Log("Battle Started");
            StartBattle();
        }
        else if(SceneManager.GetActiveScene().name == "Map")
        {
            Debug.Log("Map Loaded");
            Map = ExtensionMethod.Instantiate(MapPrefab, MapLocationPrefab, MapArrowPrefab);
            CoinText = GameObject.Find("CoinText").GetComponent<TextMeshPro>();
            CoinText.text = Gold.ToString();
        }

        // Debug
        GameObject PartyGO = new GameObject("Party");
        Party.Add(Instantiate(CreaturePrefabs[0], PartyGO.transform).GetComponent<Ally>());
        Party.Add(Instantiate(CreaturePrefabs[1], PartyGO.transform).GetComponent<Ally>());
        Party.Add(Instantiate(CreaturePrefabs[2], PartyGO.transform).GetComponent<Ally>());


        
    }

    public void StartBattle()
    {
        ExtensionMethod.Instantiate(BattleFieldPrefab, Party);
        for (int i = 0; i < Party.Count; i++)
        {
            var creature = Party[i];
            creature.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}

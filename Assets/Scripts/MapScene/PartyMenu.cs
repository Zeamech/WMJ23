using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMenu : MonoBehaviour
{
    public List<Ally> Party;
    public GameObject AllyCardPrefab;
    public List<AllyCard> AllyCards;

    // Start is called before the first frame update
    void Start()
    {
        GameObject PartyGO = GameObject.Find("Party");
        Party.AddRange(PartyGO.transform.GetComponentsInChildren<Ally>());

        int allyIndex = 0;
        foreach (Ally ally in Party)
		{
            AllyCards.Add(ExtensionMethod.Instantiate(AllyCardPrefab, allyIndex, transform, ally));
            allyIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

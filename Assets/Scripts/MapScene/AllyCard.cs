using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AllyCard : MonoBehaviour
{
    public Ally Ally;
    private float ySpacing = 1.28125f;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer allyIcon = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        allyIcon.sprite = Ally.GetComponent<SpriteRenderer>().sprite;

        TextMeshPro charmText = transform.Find("CharmMeter").Find("CharmText").GetComponent<TextMeshPro>();
        charmText.text = Ally.CharmLevel + " / 1000";

        TextMeshPro attackText1 = transform.Find("AttackText1").GetComponent<TextMeshPro>();
        attackText1.text = Ally.Attacks[0].ToString();
        TextMeshPro attackText2 = transform.Find("AttackText2").GetComponent<TextMeshPro>();
        attackText2.text = Ally.Attacks[1].ToString();
        TextMeshPro attackText3 = transform.Find("AttackText3").GetComponent<TextMeshPro>();
        attackText3.text = Ally.Attacks[2].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

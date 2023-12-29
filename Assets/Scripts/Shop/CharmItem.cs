using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharmItem : MonoBehaviour
{
    public Charm Item;
    public Sprite Icon;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Price;

    private void Awake()
    {
        Price = transform.Find("Buy").transform.Find("Price").GetComponent<TextMeshProUGUI>();
        Name = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        Description = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        Name.text = Item.Name;
        Icon = Item.ItemIcon;
        Description.text = Item.Description;
        Price.SetText(Item.Price.ToString() + " Gold");
        Icon = Item.ItemIcon;
    }
}

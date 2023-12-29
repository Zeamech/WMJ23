using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;
using System.Linq;
using UnityEditor;

public class ShopMenu : MonoBehaviour
{
    public GameObject ShopOpenButton;
    public GameObject ShopMenuScreen;
    public GameObject ShopCloseButton;

    private void Awake()
    {
        ShopOpenButton = GameObject.Find("Shop Open Button");
        ShopMenuScreen = GameObject.Find("Shop Menu");
        ShopCloseButton = GameObject.Find("Shop Close Button");
        ShopMenuScreen.SetActive(false);
    }

    public void OpenShop()
    {
        ShopOpenButton.SetActive(false);
        ShopMenuScreen.SetActive(true);
    }

    public void CloseShop() 
    {
        ShopOpenButton.SetActive(true);
        ShopMenuScreen.SetActive(false);
    }
}

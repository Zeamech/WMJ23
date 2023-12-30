using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPartyButton : MonoBehaviour
{
	public GameObject PartyMenuPrefab;
	public GameObject PartyMenu;
	[HideInInspector] public bool MenuIsVisible;
    private GameObject mainCamera;
	private SpriteRenderer spriteRenderer;

	// Start is called before the first frame update
	void Start()
    {
		MenuIsVisible = false;
		mainCamera = GameObject.Find("Main Camera");
		spriteRenderer = GetComponent<SpriteRenderer>();

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnMouseEnter()
	{
		Color color = Color.white;
		color.a = 0.8f;
		spriteRenderer.material.color = color;
	}

	private void OnMouseExit()
	{
		spriteRenderer.material.color = Color.white;
	}

	private void OnMouseDown()
	{
		if (MenuIsVisible) Destroy(PartyMenu);
		else PartyMenu = Instantiate(PartyMenuPrefab, mainCamera.transform);
		MenuIsVisible = !MenuIsVisible;
	}
}

using System.Collections.Generic;
using UnityEngine;
public class Battle : MonoBehaviour
{
	public GameObject EnemyPrefab;
	//public GameObject AllyPrefab; instantiate this in gamemanager
	public Encounter Encounter; //Sets up the enemies. Has to be passed in when you set up the battle
	public List<Ally> Party;    //Sets up your allies. Has to be passed in when you set up the battle
	private List<Enemy> Enemies;
	public void Start()
	{
		// Position the party members
		if(Party.Count == 2)
		{
			Party[0].transform.position = new Vector3(-1, 0.5f, 0);
			Party[1].transform.position = new Vector3(-1, -0.5f, 0);
		}
		else if(Party.Count == 3)
		{
			Party[0].transform.position = new Vector3(-1, 1f, 0);
			Party[1].transform.position = new Vector3(-1, 0f, 0);
			Party[2].transform.position = new Vector3(-1, -1f, 0);
		}

		// Instantiate the enemies from the encounter and enemy templates and position them
		int enemyIdx = 0;
		Enemies = new List<Enemy>();
		foreach (EnemySO template in Encounter.Enemies)
		{
			Vector3 pos = EnemyPrefab.transform.position;
			if (Encounter.Enemies.Count == 2)
			{
				if (enemyIdx == 0) pos = pos + (Vector3.up / 2.0f);
				else if (enemyIdx == 1) pos = pos - (Vector3.up / 2.0f);
			}
			else if (Encounter.Enemies.Count == 3)
			{
				if (enemyIdx == 0) pos = pos + Vector3.up;
				else if (enemyIdx == 2) pos = pos - Vector3.up;
			}
			Enemy enemy = ExtensionMethod.Instantiate(EnemyPrefab, pos, template);
			Enemies.Add(enemy); 
			enemyIdx++;
		}
	}
}

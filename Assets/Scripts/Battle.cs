using System.Collections.Generic;
using UnityEngine;
using static Ally;

public class Battle : MonoBehaviour
{
	public GameObject EnemyPrefab;
	//public GameObject AllyPrefab; move to gamemanager
	public Encounter Encounter; //Sets up the enemies. Has to be passed in when you set up the battle
	public List<Ally> Party;    //Sets up your allies. Has to be passed in when you set up the battle
	private List<Enemy> Enemies;
	private float elapsedTime = 0f;
	private int turnNumber = 0;
	public float BattleSpeed = 0.75f; //Seconds per turn
	[HideInInspector] public bool BattleOver = false;
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

	public void FixedUpdate()
	{
		elapsedTime += Time.fixedDeltaTime;
		if (!BattleOver && elapsedTime >= BattleSpeed)
		{
			elapsedTime = 0;
			int totalCharacters = Party.Count + Enemies.Count;
			List<Object> characters = new List<Object>();
			characters.AddRange(Party);
			characters.AddRange(Enemies);
			Object character = characters[turnNumber % totalCharacters]; turnNumber++;
			
			if (character.GetType() == typeof(Ally))
			{
				Ally a = (Ally)character;
				a.Attacks[a.AttackIndex](Enemies);
				a.AttackIndex = (a.AttackIndex + 1) % 3;
				Debug.Log("Ally " + a.Template.name + " attacked");

				foreach(Enemy enemy in Enemies)
					if(enemy.Health <= 0)
					{
						Debug.Log("Enemy defeated: " + enemy.Template.name);
						Enemies.Remove(enemy);
						Destroy(enemy.gameObject);
						if (Enemies.Count <= 0)
						{
							Debug.Log("You won the battle! :)");
							BattleOver = true;
						}
						break;
					}
			}
			else
			{
				Enemy enemy = (Enemy)character;
				Ally blocker = Party[Random.Range(0, Party.Count)];
				enemy.MeleeAttack(blocker);
				Debug.Log("Enemy " + enemy.Template.name + " attacked");
				if (blocker.Health <= 0)
				{
					Party.Remove(blocker);
					Debug.Log("Ally defeated: " + blocker.Template.name);
					if (Party.Count <= 0)
					{
						Debug.Log("You lost the battle! :(");
						BattleOver = true;
					}
					
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;
using static AllySO;
using Random = UnityEngine.Random;

public class Ally : MonoBehaviour
{
	public delegate void Attack(List<Enemy> enemies);
	public List<Attack> Attacks;
	public SpriteRenderer SpriteRenderer;
	public Animator Ani;
	[SerializeField] public AllySO Template;

	[HideInInspector] public int CharmLevel; //0-1000
	[HideInInspector] public List<Charm> Charms;
	[HideInInspector] public int BaseMeleePower;
	[HideInInspector] public int MaxHealth;
	[HideInInspector] public int MaxArmor;
	[HideInInspector] public int MeleePower;
	[HideInInspector] public int Health;
	[HideInInspector] public int Armor;
	[HideInInspector] public int AttackIndex = 0;
	public void Start()
	{
		SpriteRenderer = GetComponent<SpriteRenderer>();
		SpriteRenderer.sprite = Template.Icon;

		Attacks = new List<Attack>();
		Charms = new List<Charm>();
		CharmLevel = Template.BaseCharm;
		BaseMeleePower = Template.MeleePower;
		MaxHealth = Template.BaseHealth;
		MaxArmor = Template.BaseArmor;
		Ani = GetComponent<Animator>();
		Ani.SetInteger("CreatureID", Template.CreatureID);
		Reset();
		
		foreach(AttackName attack in Template.Attacks) // Can be rearranged between rounds
		{
			switch (attack)
			{
				case AttackName.BasicMeleeAttack: Attacks.Add(MeleeAttack); break;
				case AttackName.CharmMagicAttack: Attacks.Add(CharmMagicAttack); break;
				case AttackName.ArmorUp: Attacks.Add(ArmorUp); break;
			}
		}
	}

	public void Reset() // Remove debuffs and heal between rounds
	{
		Health = MaxHealth;
		Armor = MaxArmor;
		MeleePower = BaseMeleePower;
	}

	public void ApplyCharm(Charm charm)
	{
		//Modify max hp, max armor, upgrade attacks, etc.
		switch(charm.Type)
		{
			case Charm.CharmType.HealthCharm: MaxHealth += 5; break;
			case Charm.CharmType.ArmorCharm: MaxArmor += 8; break;
			case Charm.CharmType.AttackCharm: BaseMeleePower += 2; break;
			case Charm.CharmType.CharmCharm: CharmLevel = Math.Min(1000, CharmLevel + 200); break;
		}
	}


	// ### Attack Functions ###
	public void MeleeAttack(List<Enemy> enemies)
	{
		int enemyIdx = Random.Range(0, enemies.Count);
		enemies[enemyIdx].Health -= MeleePower;
		Ani.SetTrigger("Attack");
	}

	public void CharmMagicAttack(List<Enemy> enemies)
	{

	}

	public void ArmorUp(List<Enemy> enemies)
	{
		Armor += 8;
	}
}
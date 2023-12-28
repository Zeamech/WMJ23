using UnityEngine;

public class Enemy : MonoBehaviour
{
	public EnemySO Template;
	[HideInInspector] public int Health;
	[HideInInspector] public int Armor;
	[HideInInspector] public int Attack;

	[HideInInspector] public Sprite Icon;
	[HideInInspector] public Animator Animator;

	public void Start()
	{
		Attack = Template.BaseAttack;
		Health = Template.BaseHealth;
		Armor = Template.BaseArmor;
		Icon = Template.Icon;
		Animator = Template.Animator;
	}

	// ### Enemy Attacks ### 
	public void MeleeAttack(Ally ally)
	{
		ally.Health -= Attack;
	}
}
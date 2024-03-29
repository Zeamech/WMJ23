﻿using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemies", order = 1)]
public class EnemySO : ScriptableObject
{
	public string Name;
	public string Description;
	public int BaseAttack;
	public int BaseHealth;
	public int BaseArmor;

	public Sprite Icon;
	public Animator Animator;
}

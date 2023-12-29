using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ally", menuName = "ScriptableObjects/Allies", order = 1)]
public class AllySO : ScriptableObject
{
	public List<AttackName> Attacks;
	public Sprite Icon;
	public Animator Animator; 

	public string CreatureName;
	public int CreatureID;
	public int MeleePower;
	public int BaseHealth;
	public int BaseCharm; // 0-1000
	public int BaseArmor;

	public enum AttackName
	{
		BasicMeleeAttack,
		CharmMagicAttack,
		ArmorUp
	}
}

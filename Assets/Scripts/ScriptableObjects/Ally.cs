using UnityEngine;

[CreateAssetMenu(fileName = "Ally", menuName = "ScriptableObjects/Allies", order = 1)]
public class Ally : ScriptableObject
{
	public Sprite Icon;
	public Animator Animator;

	public string CreatureName;
	public int BaseHealth;
	public int BaseCharm; // 0-1000
	public int BaseArmor;
}

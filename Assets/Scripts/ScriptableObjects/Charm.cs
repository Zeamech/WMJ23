using UnityEngine;

[CreateAssetMenu(fileName = "Charm", menuName = "ScriptableObjects/Charms", order = 1)]
public class Charm : ScriptableObject
{
	[SerializeField]
	public CharmType Type;
	public Sprite Icon;
	public string Name;
	public string Description;

	public enum CharmType
	{
		HealthCharm,
		ArmorCharm,
		AttackCharm,
		CharmCharm
	}
}
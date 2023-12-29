using UnityEngine;

[CreateAssetMenu(fileName = "Charm", menuName = "ScriptableObjects/Charms", order = 1)]
public class Charm : ScriptableObject
{
	[SerializeField]
	public CharmType Type;
	public Sprite ItemIcon;
	public string Name;
	public string Description;
	public int Price;

	public enum CharmType
	{
		HealthCharm,
		ArmorCharm,
		AttackCharm,
		CharmCharm
	}
}

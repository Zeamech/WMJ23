using UnityEngine;

[CreateAssetMenu(fileName = "Charm", menuName = "ScriptableObjects/Charms", order = 1)]
public class Charm : ScriptableObject
{
	public Sprite Icon;
	public string Name;
	public string Description;
}
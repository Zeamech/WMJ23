using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Encounter", menuName = "ScriptableObjects/Encounters", order = 1)]
public class Encounter : ScriptableObject
{
    [SerializeField]
    public List<Enemy> Enemies;
}
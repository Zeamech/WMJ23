using UnityEngine;

public static class ExtensionMethod
{
    public static Enemy Instantiate(Object original, Vector3 position, EnemySO Template)
    {
        GameObject enemy = Object.Instantiate(original, position, Quaternion.identity) as GameObject;

		Enemy e = enemy.transform.GetComponent<Enemy>();
        e.Template = Template;
        return e;
    }
}
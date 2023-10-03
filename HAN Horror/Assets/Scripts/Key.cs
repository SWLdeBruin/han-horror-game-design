using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "Scriptable Objects/Key")]
public class Key : ScriptableObject
{
    public new string name;

    public Key(string name)
    {
        this.name = name;
    }
}

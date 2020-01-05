using UnityEngine;

public enum PropType {Pot, Bench, Column}

[CreateAssetMenu]
public class PropsProfile : ScriptableObject
{
    public int propValue;
    public PropType propType;
}

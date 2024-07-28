using UnityEngine;

[System.Serializable]
public class MonsterAbility
{
    [SerializeField] private string _name = "...";
    [SerializeField] private int _damage = 1;
    [SerializeField] ElementType _element = ElementType.None;
}

public enum ElementType {
    None,
    Earth,
    Fire,
    Wind,
    Water,
    Hearth
}

using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData_", menuName = "UnitData/Monster")]
public class MonsterData : ScriptableObject
{
    [Header("General Stats")]
    [Space]
    [SerializeField]
    private string _name = "...";

    [CustomEditorAttributes.HorizontalLine(color: CustomEditorAttributes.EColor.White)]
    [Space]

    [SerializeField]
    [Tooltip("Select the type of your monster.")]
    private MonsterType _typeOfMonster = MonsterType.Vampire;

    [SerializeField]
    [Range(0, 100)]
    private float _changeToDropItem = 20;

    [SerializeField]
    [Tooltip("Radius size where monster will see the player.")]
    private float _rangeOfAwareness = 10;
    [SerializeField]
    private bool _canEnterCombat = true;

    [CustomEditorAttributes.HorizontalLine(color: CustomEditorAttributes.EColor.White)]
    [Space]

    [Header("Combat Stats")]
    [Space]
    [SerializeField] private int _damage = 1;
    [SerializeField] private int _health = 1;
    [SerializeField] private int _speed = 1;

    [CustomEditorAttributes.HorizontalLine(color: CustomEditorAttributes.EColor.White)]
    [Space]

    [Header("Dialogue")]
    [Space]
    [SerializeField]
    [Tooltip("Speaks dialogue when entering combat")]
    [TextArea()]
    private string _battleCry;

    // ---- GETTERS ----
    public MonsterType TypeOfMonster => _typeOfMonster;
    
    public string Name => _name;
    public string BattleCry => _battleCry;
    
    public float ChangeToDropItem => _changeToDropItem;
    public float RangeOfAwareness => _rangeOfAwareness;
    
    public bool CanEnterCombat => _canEnterCombat;
    
    public int Damage => _damage;
    public int Health => _health;
    public int Speed => _speed;
    
}

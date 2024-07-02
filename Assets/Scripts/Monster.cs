using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("General Stats")]
    [Space]
    [SerializeField] 
    private string _name;

    [CustomEditorAttributes.HorizontalLine(color: CustomEditorAttributes.EColor.White)]
    [Space]

    [SerializeField]
    [Tooltip("Select the type of your monster.")]
    private MonsterType _typeOfMonster = MonsterType.Vampire;

    [SerializeField] [Range(0, 100)] 
    private float _changeToDropItem;

    [SerializeField] [Tooltip("Radius size where monster will see the player.")]
    private float _rangeOfAwareness;

    [CustomEditorAttributes.HorizontalLine(color: CustomEditorAttributes.EColor.White)]
    [Space]

    [Header("Combat Stats")]
    [Space]
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private int _speed;

    [CustomEditorAttributes.HorizontalLine(color: CustomEditorAttributes.EColor.White)]
    [Space]

    [Header("Dialogue")]
    [Space]
    [SerializeField] 
    [Tooltip("Speaks dialogue when entering combat")]
    [TextArea()]
    private string _battleCry;

}

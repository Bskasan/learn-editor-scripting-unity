using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterData _monsterData;

    private void Awake() {
        Debug.Log("Name: " + _monsterData.GetNameValue());
        Debug.Log("Damage: " + _monsterData.GetDamageValue());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterData _monsterData;

    [Seperator()]
    [SerializeField] private float _jumpForce;

    private void Awake() {
        Debug.Log("Name: " + _monsterData.Name);
        Debug.Log("Damage: " + _monsterData.Damage);
        Debug.Log("Monster Type: " + _monsterData.TypeOfMonster);
        Debug.Log("Speed: " + _monsterData.Speed);
        Debug.Log("Battle Cry: " + _monsterData.BattleCry);
    }

    // If selected...
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _monsterData.RangeOfAwareness);
    }
}

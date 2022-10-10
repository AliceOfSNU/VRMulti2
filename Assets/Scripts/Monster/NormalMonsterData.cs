using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NormalMonster", menuName = "CreateMonsterData/NormalMonster", order = int.MaxValue)]
public class NormalMonsterData : ScriptableObject
{
    [SerializeField] private float damage;
    public float Damage { get { return damage; } set { damage = value; } }

    [SerializeField] private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

}

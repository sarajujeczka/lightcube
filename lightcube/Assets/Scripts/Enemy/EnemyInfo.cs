using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Enemy", menuName = "ZeTon/Enemy/New Enemy", order = 2)]
public class EnemyInfo : ScriptableObject
{
    [Range(0.1f,3)]
    public float fireRate = 0.75F;
    [Range(0.1f, 3)]
    public float moveRate = 1;
    [Range(1, 100)]
    public float force = 70f;
    public Bullet bullet;
    public Enemy prefab;
    public Colour[] colours;
}

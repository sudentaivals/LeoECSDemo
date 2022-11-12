using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyInitData : ScriptableObject
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] float _speed = 1.25f;
    [SerializeField] float _searchRadius = 2f;

    public float SearchRadius => _searchRadius;
    public GameObject EnemyPrefab => _enemyPrefab;

    public float Speed => _speed;

    public static EnemyInitData LoadFromAssets => Resources.Load(@"Data/EnemyData") as EnemyInitData;
}

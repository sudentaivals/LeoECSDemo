using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerInitData : ScriptableObject
{
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] float _speed;

    public GameObject PlayerPrefab => _playerPrefab;

    public float Speed => _speed;

    public static PlayerInitData LoadFromAssets => Resources.Load(@"Data/PlayerData") as PlayerInitData;
}

using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public event Action<IEnemy> OnSpawn;

    [SerializeField] private Enemy _enemy;

    public void Spawn () {
        var newEnemy = Instantiate(_enemy);
        newEnemy.transform.position = transform.position;

        OnSpawn?.Invoke(newEnemy);
    }
}

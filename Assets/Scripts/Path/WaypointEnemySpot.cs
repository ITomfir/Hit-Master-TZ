using System;
using System.Collections.Generic;
using UnityEngine;

public class WaypointEnemySpot : BaseWaypoint {
    public override event Action OnComplite;

    [SerializeField] private EnemySpawner[] _enemySpawners;

    private List<IEnemy> _livingEnemies = new List<IEnemy>();

    private void OnEnable() {
        foreach (var spawner in _enemySpawners) spawner.OnSpawn += OnSpawnEnemy;
    }

    private void OnDisable() {
        foreach (var spawner in _enemySpawners) spawner.OnSpawn -= OnSpawnEnemy;
    }

    public override void Active() {
        if (_livingEnemies.Count == 0) OnComplite?.Invoke();
    }

    private void OnSpawnEnemy (IEnemy enemy) {
        _livingEnemies.Add(enemy);
        enemy.OnDead += OnEnemyDead;

        void OnEnemyDead () {
            OnDead(enemy);
            enemy.OnDead -= OnEnemyDead;
        }
    }

    public void OnDead (IEnemy enemy) {
        _livingEnemies.Remove(enemy);

        if (_livingEnemies.Count == 0) OnComplite?.Invoke();
    }
}

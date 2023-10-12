using System.Collections;
using UnityEngine;
using System;

public class Pistol : MonoBehaviour, IWeapon {
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private Bullet _bullet;
    
    private ObjectPool<Bullet> _pool;

    private void Awake () {
        _pool = new ObjectPool<Bullet> (Preload, Get, Return, 10);
    }

    public void Shot (Vector3 point) {
        var bullet = _pool.Get();
        bullet.transform.position = _shotPoint.position;
        bullet.transform.LookAt(point);
    }

    private Bullet Preload () => Instantiate(_bullet);

    private void Get (Bullet bullet) {
        bullet.gameObject.SetActive(true);

        bullet.OnHit += OnHit;
        StartCoroutine(TimerReturn(3f, OnHit));

        void OnHit () {
            _pool.Return(bullet);
            bullet.OnHit -= OnHit;
        }
    }

    private void Return (Bullet bullet) => bullet.gameObject.SetActive(false);

    private IEnumerator TimerReturn (float time, Action callback) {
        yield return new WaitForSeconds (time);

        callback?.Invoke();
    } 
}

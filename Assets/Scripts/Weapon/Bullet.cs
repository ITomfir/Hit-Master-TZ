using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IBullet {
    public event Action OnHit;

    [SerializeField] private float _speed;
    [SerializeField] private TrailRenderer _trail;
    
    private Rigidbody _rigidbody;
    
    private void Awake () {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDisable() {
        _trail.Clear();
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void FixedUpdate() {        
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.TryGetComponent<IDamageable>(out var damageable)) {
            var hitData = new HitData();
            
            damageable.Hit(hitData);
        }
        
        OnHit?.Invoke();
    }
}

using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy {
    public event Action OnDead;

    [SerializeField] private HitBox[] hitBoxes;
    [SerializeField] private Animator _animator;
    [SerializeField] private SubstitutetRagdoll _ragdoll;

    private void OnEnable() {
        foreach (var hitBox in hitBoxes) hitBox.OnHit += OnHit;
    }
        
    private void OnDisable() {
        foreach (var hitBox in hitBoxes) hitBox.OnHit -= OnHit;
    }

    private void OnHit (HitData hit) {
        OnDead?.Invoke();
        _ragdoll.EnableRagdoll();
        _animator.enabled = false;
    }
}

using System;
using UnityEngine;

public class HitBox : MonoBehaviour, IDamageable {
    public Action<HitData> OnHit;
    
    public void Hit (HitData hit) => OnHit?.Invoke(hit);
}

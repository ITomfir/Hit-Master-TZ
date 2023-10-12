using UnityEngine;
using System;

public class ArrivalWaypoint : BaseWaypoint {
    public override event Action OnComplite;

    [Range(-180, 180)] public float _directionAngle;
    
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<Player>(out var player)) OnComplite?.Invoke();
    }

    public Quaternion GetDirectionAngle () {
        return Quaternion.Euler(0, _directionAngle, 0) * transform.rotation;
    }

    private void OnDrawGizmos() {
        var vector = GetDirectionAngle() * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + vector);
    }
}

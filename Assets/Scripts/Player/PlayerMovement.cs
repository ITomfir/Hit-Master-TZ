using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _rotationSpeed;

    public void MoveTo (Vector3 point) {
        _agent.SetDestination(point);
    }

    public void RotateTo (Quaternion rotation) {
        StartCoroutine(Rotate(rotation));
    }

    private IEnumerator Rotate (Quaternion rotation) {
        _agent.updateRotation = false;

        while (0.2f < Quaternion.Angle(transform.rotation, rotation)) {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation,  Time.deltaTime * _rotationSpeed);

            yield return new WaitForFixedUpdate ();
        }

        _agent.updateRotation = true;
        
        yield return null;
    }
}

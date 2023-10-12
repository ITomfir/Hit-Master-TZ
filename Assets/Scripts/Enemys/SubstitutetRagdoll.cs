using UnityEngine;

public class SubstitutetRagdoll : MonoBehaviour {
    [SerializeField] private Rigidbody[] _bones;
    
    private void Awake() {
        foreach (var bone in _bones) bone.isKinematic = true;
    }

    public void EnableRagdoll () {
        foreach (var bone in _bones) bone.isKinematic = false;
    }

    public void DisableRagdoll () {
        foreach (var bone in _bones) bone.isKinematic = true;
    }
}

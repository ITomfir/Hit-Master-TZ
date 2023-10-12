using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    private const string ANIMKEY_MOVE = "Run";

    [SerializeField] private Animator _animator;

    public void Idle () => _animator.SetBool(ANIMKEY_MOVE, false);
    public void Move () => _animator.SetBool(ANIMKEY_MOVE, true);
}

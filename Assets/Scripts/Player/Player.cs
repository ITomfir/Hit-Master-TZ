using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerAnimator _animator;

    [SerializeField] private Pistol _pistol;

    private IWeapon _weapon;
    private PlayerInput _playerInput;
    private Camera _camera;

    private void Awake() {
        _camera = Camera.main;
        _playerInput = new PlayerInput ();
        _weapon = _pistol;

        _playerInput.Init();
    }

    private void OnEnable() {
        _playerInput.OnShoot += Shoot;
    }

    private void OnDisable() {
        _playerInput.OnShoot -= Shoot;
    }

    private void Shoot (Vector2 mousePosition) {
        Ray ray = _camera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        Vector3 hitpoint;
 
        hitpoint = Physics.Raycast(ray, out hit) ? hit.point : ray.GetPoint(100f);

        _weapon.Shot(hitpoint);
    }

    public void MoveTo (Vector3 pos) {
        _movement.MoveTo(pos);
        _animator.Move();
    }

    public void RotateTo (Quaternion rotation) {
        _movement.RotateTo(rotation);
        _animator.Idle();
    }
}

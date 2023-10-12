using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [SerializeField] private Path _path;
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner[] _enemySpawners;
    [SerializeField] private StartPanel _startPanel;

    private void OnEnable() {
        _startPanel.OnStart += OnStart;
        _path.OnChangeWaypoint += OnChangeWaypoint; 
        _path.OnAllPathComplite += OnEnd;
    }

    private void OnDisable() {
        _startPanel.OnStart -= OnStart;
        _path.OnChangeWaypoint -= OnChangeWaypoint; 
        _path.OnAllPathComplite -= OnEnd;
    }

    private void OnStart () {
        foreach (var spawner in _enemySpawners) spawner.Spawn();
    
        _path.Begin();
    }

    private void OnChangeWaypoint (IWaypoint waypoint) {
        if (waypoint is ArrivalWaypoint) {
            var arrivalWaypoint = (ArrivalWaypoint)waypoint;
            _player.MoveTo(arrivalWaypoint.transform.position);
            
            arrivalWaypoint.OnComplite += RotateOnEndMove;

            void RotateOnEndMove () {
                _player.RotateTo(arrivalWaypoint.GetDirectionAngle());
                arrivalWaypoint.OnComplite -= RotateOnEndMove;
            }
        }
    }

    private void OnEnd () => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

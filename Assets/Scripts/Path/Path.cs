using System;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
    public event Action<IWaypoint> OnChangeWaypoint;
    public event Action OnAllPathComplite;
    
    [SerializeField] private List<BaseWaypoint> _waypoints;

    private int _currentWaypointIndex;

    public void Begin () => OnChangeWaypoint?.Invoke(_waypoints[_currentWaypointIndex]);

    private void OnEnable () => SubscribeCurrentWaypoint();

    private void OnDisable () => UnsubscribeCurrentWaypoint();

    private void OnCompliteWaypoint () {
        UnsubscribeCurrentWaypoint();
        
        if (_currentWaypointIndex == _waypoints.Count - 1) {
            OnAllPathComplite?.Invoke();
            return;
        }

        _currentWaypointIndex++;

        OnChangeWaypoint?.Invoke(_waypoints[_currentWaypointIndex]);
        SubscribeCurrentWaypoint();
    
        _waypoints[_currentWaypointIndex].Active();
    }

    private void SubscribeCurrentWaypoint () => _waypoints[_currentWaypointIndex].OnComplite += OnCompliteWaypoint;

    private void UnsubscribeCurrentWaypoint () => _waypoints[_currentWaypointIndex].OnComplite -= OnCompliteWaypoint;
}

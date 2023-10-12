using UnityEngine;
using System;

public abstract class BaseWaypoint : MonoBehaviour, IWaypoint {
    public abstract event Action OnComplite;

    public virtual void Active () { }
}

using System;

public interface IWaypoint {
    event Action OnComplite;

    void Active ();
}

using System.Collections.Generic;
using System;
using UnityEngine;

public class ObjectPool<T> {
    private readonly Func<T> _preloadFunc;
    private readonly Action<T> _getAction;
    private readonly Action<T> _returnAction;

    private Queue<T> _pool = new Queue<T>();

    public ObjectPool (Func<T> preloadFunc, Action<T> getAction,  Action<T> returnAction, int preloadCount) {
        _preloadFunc = preloadFunc;
        _getAction = getAction;
        _returnAction = returnAction;

        if (preloadFunc == null) return;
    
        for (int i = 0; i < preloadCount; i++) {
            Return(preloadFunc());
        }
    }

    public T Get () {
        Debug.Log(_pool.Count);
        T item = _pool.Count > 0 ? _pool.Dequeue() : _preloadFunc();
        _getAction(item);
        
        return item;
    }

    public void Return (T item) {
        _returnAction(item);
        _pool.Enqueue(item);
    }
}

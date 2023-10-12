using System;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public event Action OnStart;

    [SerializeField] private Button _button;

    private void OnEnable () => _button.onClick.AddListener(OnTab);
    private void OnDisable() => _button.onClick.RemoveListener(OnTab);

    private void OnTab () {
        OnStart?.Invoke();
        gameObject.SetActive(false);
    }
}

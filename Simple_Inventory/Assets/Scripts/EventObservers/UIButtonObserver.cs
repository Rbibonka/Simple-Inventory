using System;
using UnityEngine;
using UnityEngine.UI;

public sealed class UIButtonObserver : MonoBehaviour
{
    public event Action ButtonClicked;

    [SerializeField]
    private Button btn_Button;

    private void Awake()
    {
        btn_Button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDestroy()
    {
        btn_Button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        ButtonClicked?.Invoke();
    }
}
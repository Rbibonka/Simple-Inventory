using System;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class PointerExitObserver : MonoBehaviour, IPointerExitHandler
{
    public event Action PointerExit;

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExit?.Invoke();
    }
}
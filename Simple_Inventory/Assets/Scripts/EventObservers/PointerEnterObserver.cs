using System;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class PointerEnterObserver : MonoBehaviour, IPointerEnterHandler
{
    public event Action PointerEnter;

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnter?.Invoke();
    }
}
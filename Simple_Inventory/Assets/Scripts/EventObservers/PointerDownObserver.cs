using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerDownObserver : MonoBehaviour, IPointerDownHandler
{
    public event Action<PointerEventData> PointerDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        PointerDown?.Invoke(eventData);
    }
}
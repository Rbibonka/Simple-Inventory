using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemEventsObserver : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public event Action<Vector2> Drag;
    public event Action<Vector2> PointerDown;

    public void OnDrag(PointerEventData eventData)
    {
        Drag?.Invoke(eventData.delta);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PointerDown?.Invoke(eventData.position);
    }
}
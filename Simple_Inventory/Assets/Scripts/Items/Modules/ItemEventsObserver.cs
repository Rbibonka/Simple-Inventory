using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemEventsObserver : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public event Action<Vector2> Drag;
    public event Action<Vector2> PointerDown;
    public event Action PointerUp;

    public void OnDrag(PointerEventData eventData)
    {
        Drag?.Invoke(eventData.delta);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PointerDown?.Invoke(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PointerUp?.Invoke();
    }
}
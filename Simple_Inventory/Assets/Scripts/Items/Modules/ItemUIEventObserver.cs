using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemUIEventObserver : MonoBehaviour, IDragHandler
{
    public event Action<Vector2> Drag;

    public void OnDrag(PointerEventData eventData)
    {
        Drag?.Invoke(eventData.delta);
    }
}
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementDragObserver : MonoBehaviour, IDragHandler
{
    public event Action<PointerEventData> Drag;

    public void OnDrag(PointerEventData eventData)
    {
        Drag?.Invoke(eventData);
    }
}
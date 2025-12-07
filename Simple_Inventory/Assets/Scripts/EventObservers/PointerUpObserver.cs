using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerUpObserver : MonoBehaviour, IPointerUpHandler
{
    public event Action PointerUp;

    public void OnPointerUp(PointerEventData eventData)
    {
        PointerUp?.Invoke();
    }
}
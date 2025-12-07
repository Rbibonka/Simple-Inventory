using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerExitObserver : MonoBehaviour, IPointerExitHandler
{
    public event Action PointerExit;

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExit?.Invoke();
    }
}
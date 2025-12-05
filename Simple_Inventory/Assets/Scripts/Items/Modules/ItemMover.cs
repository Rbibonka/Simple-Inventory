using System;
using UnityEngine;

public class ItemMover : IDisposable
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private ItemEventObserver uiEventObserver;

    public ItemMover(RectTransform rectTransform, ItemEventObserver uiEventObserver, Canvas canvas)
    {
        this.rectTransform = rectTransform;
        this.uiEventObserver = uiEventObserver;
        this.canvas = canvas;

        this.uiEventObserver.Drag += OnDrag;
    }

    private void OnDrag(Vector2 delta)
    {
        rectTransform.anchoredPosition += delta / canvas.scaleFactor;
    }

    public void Dispose()
    {
        uiEventObserver.Drag -= OnDrag;
    }
}
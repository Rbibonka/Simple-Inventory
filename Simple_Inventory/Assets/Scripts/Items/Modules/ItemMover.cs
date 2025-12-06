using System;
using UnityEngine;

public class ItemMover
{
    private RectTransform rectTransform;
    private Canvas canvas;

    public ItemMover(RectTransform rectTransform, Canvas canvas)
    {
        this.rectTransform = rectTransform;
        this.canvas = canvas;
    }

    public void Move(Vector2 delta)
    {
        rectTransform.anchoredPosition += delta / canvas.scaleFactor;
    }
}
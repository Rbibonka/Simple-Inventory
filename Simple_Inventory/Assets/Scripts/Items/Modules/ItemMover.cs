using DG.Tweening;
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

    public void MoveToDefault()
    {
        var a = rectTransform.DOLocalMove(Vector3.zero, 0.2f);
    }
}
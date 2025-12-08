using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMover
{
    private RectTransform rectTransform;
    private Canvas canvas;

    public ItemMover(RectTransform rectTransform, Canvas canvas)
    {
        this.rectTransform = rectTransform;
        this.canvas = canvas;
    }

    public void Move(PointerEventData eventData)
    {
        Vector2 deltaPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out deltaPos
        );

        rectTransform.localPosition += (Vector3)deltaPos - rectTransform.localPosition;
    }

    public void MoveTo(Vector3 target)
    {
        rectTransform.DOMove(target, 0.2f);
    }
}
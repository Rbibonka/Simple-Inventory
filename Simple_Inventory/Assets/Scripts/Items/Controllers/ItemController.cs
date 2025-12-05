using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private ItemUIEventObserver uiEventObserver;

    private ItemMover itemMover;

    public void Initialize(Canvas canvas)
    {
        itemMover = new(rectTransform, uiEventObserver, canvas);
    }

    public void SetToSocket(RectTransform socketTransform)
    {
        rectTransform.SetParent(socketTransform, false);
        rectTransform.localPosition = Vector3.zero;
    }
}
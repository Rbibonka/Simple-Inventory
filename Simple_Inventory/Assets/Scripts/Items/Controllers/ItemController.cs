using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private Image img_Item;

    [SerializeField]
    private ItemEventsObserver uiEventObserver;

    private ItemMover itemMover;
    private ItemModel itemModel;

    public void Initialize(Canvas canvas)
    {
        uiEventObserver.Drag += OnDrag;
        uiEventObserver.PointerDown += PointerDown;

        itemMover = new(rectTransform, canvas);

        itemModel = new(itemMover, rectTransform);
    }

    private void PointerDown(Vector2 targetPosition)
    {
        itemModel.SetPosition(targetPosition);
    }

    private void OnDrag(Vector2 delta)
    {
        itemModel.Drag(delta);
    }

    public void SetToSocket(RectTransform socketTransform)
    {
        itemModel.SetToSocker(socketTransform);
    }
}
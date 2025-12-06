using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour, IDisposable
{
    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private Image img_Item;

    [SerializeField]
    private ItemEventsObserver uiEventObserver;

    private ItemMover itemMover;
    private ItemModel itemModel;
    private ItemView itemView;

    private bool disposed;

    public void Initialize(Canvas canvas)
    {
        uiEventObserver.Drag += OnDrag;
        uiEventObserver.PointerDown += PointerDown;
        uiEventObserver.PointerUp += PointerUp;

        itemView = new(img_Item);

        itemMover = new(rectTransform, canvas);

        itemModel = new(itemMover, rectTransform);
    }

    public void Dispose()
    {
        if (disposed)
        {
            return;
        }

        uiEventObserver.Drag -= OnDrag;
        uiEventObserver.PointerDown -= PointerDown;
        uiEventObserver.PointerUp -= PointerUp;

        disposed = true;
    }

    public void SetToSocket(RectTransform socketTransform)
    {
        itemModel.SetToSocker(socketTransform);
    }

    private void PointerDown(Vector2 targetPosition)
    {
        itemModel.SetPosition(targetPosition);
        itemView.SelectItem();
    }

    private void PointerUp()
    {
        itemView.UnselectItem();
    }

    private void OnDrag(Vector2 delta)
    {
        itemModel.Drag(delta);
    }
}
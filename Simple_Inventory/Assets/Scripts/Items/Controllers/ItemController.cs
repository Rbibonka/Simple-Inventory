using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour, IDisposable
{
    public event Action ItemSelected;

    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private Image img_Item;

    [SerializeField]
    private ItemEventsObserver uiEventObserver;

    private ItemMover itemMover;
    private ItemModel itemModel;
    private ItemView itemView;

    private bool isDisposed;

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
        if (isDisposed)
        {
            return;
        }

        uiEventObserver.Drag -= OnDrag;
        uiEventObserver.PointerDown -= PointerDown;
        uiEventObserver.PointerUp -= PointerUp;

        isDisposed = true;
    }

    public void MoveToDefault()
    {
        itemMover.MoveToDefault();
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
        ItemSelected?.Invoke();
    }

    private void OnDrag(Vector2 delta)
    {
        itemModel.Drag(delta);
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class ItemController : MonoBehaviour, IDisposable
{
    public int CellsCount => itemModel.CellsCount;

    public RectTransform RectTransform => rectTransform;

    public event Action ItemDragged;
    public event Action ItemPointerUp;

    public IReadOnlyList<RectTransform> RectTransforms => rectTransforms;

    [SerializeField]
    private RectTransform[] rectTransforms;

    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private Image img_Item;

    [SerializeField]
    private PointerUpObserver pointerUpObserver;

    [SerializeField]
    private PointerDownObserver pointerDownObserver;

    [SerializeField]
    private ElementDragObserver elementDragObserver;

    private ItemModel itemModel;
    private ItemView itemView;

    private bool isDisposed;

    public void Initialize(Canvas canvas, int cellsCount)
    {
        elementDragObserver.Drag += OnDrag;
        pointerDownObserver.PointerDown += PointerDown;
        pointerUpObserver.PointerUp += PointerUp;

        itemView = new(img_Item);
        itemModel = new(rectTransform, cellsCount, canvas);
    }

    public void Dispose()
    {
        if (isDisposed)
        {
            return;
        }

        elementDragObserver.Drag -= OnDrag;
        pointerDownObserver.PointerDown -= PointerDown;
        pointerUpObserver.PointerUp -= PointerUp;

        isDisposed = true;
    }

    public void MoveToDefault()
    {
        itemModel.MoveToDefault();
    }

    public void SetToSocket(RectTransform socketTransform)
    {
        itemModel.SetToSocker(socketTransform);
    }

    private void PointerDown(PointerEventData pointerEventData)
    {
        itemModel.SetPosition(pointerEventData.position);
        itemView.SelectItem();
    }

    private void PointerUp()
    {
        itemView.UnselectItem();
        ItemPointerUp?.Invoke();
    }

    private void OnDrag(PointerEventData pointerEventData)
    {
        itemModel.Drag(pointerEventData.delta);
        ItemDragged?.Invoke();
    }
}
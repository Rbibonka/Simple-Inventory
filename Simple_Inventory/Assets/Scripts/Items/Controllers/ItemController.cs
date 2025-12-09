using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class ItemController : MonoBehaviour, IDisposable
{
    public ItemType ItemType => itemModel.ItemType;

    public int Level => itemModel.Level;

    public int CellsCount => itemModel.CellsCount;

    public RectTransform RectTransform => rectTransform;

    public event Action ItemDragged;
    public event Action ItemPointerUp;

    public IReadOnlyList<ItemCellController> ItemsCells => itemsCellsControllers;

    [SerializeField]
    private ParticleSystem upgradeEffect;

    [SerializeField]
    private ItemCellController[] itemsCellsControllers;

    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private Image img_Item;

    [SerializeField]
    private Image img_ItemImage;

    [SerializeField]
    private PointerUpObserver pointerUpObserver;

    [SerializeField]
    private PointerDownObserver pointerDownObserver;

    [SerializeField]
    private ElementDragObserver elementDragObserver;

    private ItemModel itemModel;
    private ItemView itemView;

    private bool isDisposed;

    public void Initialize(Canvas canvas, ItemType itemType)
    {
        elementDragObserver.Drag += OnDrag;
        pointerDownObserver.PointerDown += PointerDown;
        pointerUpObserver.PointerUp += PointerUp;

        itemView = new(img_Item, img_ItemImage, upgradeEffect);
        itemModel = new(rectTransform, itemsCellsControllers.Length, itemType, canvas);
    }

    public void Deinitialize()
    {
        itemModel.ClearOccupyCells();
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

    public void SetToGrid(Vector3 target, IReadOnlyList<GridCellController> currentSelectedCells)
    {
        rectTransform.position = target;
        itemModel.SetOccupyCells(currentSelectedCells);
    }

    public void MoveToDefault()
    {
        itemModel.MoveToDefault();
    }

    public void SetToSocket(RectTransform socketTransform)
    {
        itemModel.SetToSocket(socketTransform);
    }

    public void UpdateLevel()
    {
        itemModel.UpdateLevel();
        itemView.PlayUpgradeEffect();
    }

    public void UpdateImage(Sprite sprite)
    {
        itemView.UpdateImage(sprite);
    }

    private void PointerDown(PointerEventData pointerEventData)
    {
        itemModel.SetPosition(pointerEventData);
        itemModel.ClearOccupyCells();
        itemView.SelectItem();
    }

    private void PointerUp()
    {
        itemView.UnselectItem();
        ItemPointerUp?.Invoke();
    }

    private void OnDrag(PointerEventData pointerEventData)
    {
        itemModel.Drag(pointerEventData);
        ItemDragged?.Invoke();
    }
}
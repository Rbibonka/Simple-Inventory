using UnityEngine;
using UnityEngine.UI;

public sealed class ItemView
{
    private Image img_Item;
    private Image itemImage;
    private ParticleSystem explosion;

    public ItemView(Image img_Item, Image itemImage, ParticleSystem explosion)
    {
        this.img_Item = img_Item;
        this.itemImage = itemImage;
        this.explosion = explosion;
    }

    public void SelectItem()
    {
        img_Item.raycastTarget = false;
    }

    public void UnselectItem()
    {
        img_Item.raycastTarget = true;
    }

    public void UpdateImage(Sprite sprite)
    {
        itemImage.sprite = sprite;
    }

    public void PlayUpgradeEffect()
    {
        explosion.Play();
    }
}
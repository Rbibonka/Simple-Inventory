using UnityEngine.UI;

public class ItemView
{
    private Image img_Item;

    public ItemView(Image img_Item)
    {
        this.img_Item = img_Item;
    }

    public void SelectItem()
    {
        img_Item.raycastTarget = false;
    }

    public void UnselectItem()
    {
        img_Item.raycastTarget = true;
    }
}
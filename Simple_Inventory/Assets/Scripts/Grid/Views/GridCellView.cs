using UnityEngine.UI;

public class GridCellView
{
    private Image img_GridCell;
    private GridCellConfig gridCellConfig;

    public GridCellView(Image img_GridCell, GridCellConfig gridCellConfig)
    {
        this.img_GridCell = img_GridCell;
        this.gridCellConfig = gridCellConfig;
    }

    public void SelectCell()
    {
        img_GridCell.color = gridCellConfig.SelectedColor;
    }

    public void UnselectCell()
    {
        img_GridCell.color = gridCellConfig.DefaultColor;
    }
}
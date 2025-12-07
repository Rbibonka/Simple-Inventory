using UnityEngine.UI;

public sealed
    class GridCellView
{
    private Image img_GridCell;
    private GridCellConfig gridCellConfig;

    public GridCellView(Image img_GridCell, GridCellConfig gridCellConfig)
    {
        this.img_GridCell = img_GridCell;
        this.gridCellConfig = gridCellConfig;
    }

    public void Deactivate()
    {
        img_GridCell.color = gridCellConfig.DeactivatedColor;
    }

    public void HoverCell()
    {
        img_GridCell.color = gridCellConfig.HoveredColor;
    }

    public void SelectCell()
    {
        img_GridCell.color = gridCellConfig.SelectedColor;
    }

    public void DefaultCell()
    {
        img_GridCell.color = gridCellConfig.DefaultColor;
    }
}
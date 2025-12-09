public sealed class GridCellModel
{
    private bool isActive;

    public bool IsActive => isActive;

    private bool isOccupy;

    public bool IsOccupy => isOccupy;

    public GridCellModel(bool isActive)
    {
        this.isActive = isActive;
    }

    public void OccupyCell()
    {
        isOccupy = true;
    }

    public void FreeCell()
    {
        isOccupy = false;
    }
}
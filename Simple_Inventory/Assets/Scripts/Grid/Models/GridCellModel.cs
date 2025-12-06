using UnityEngine;

public class GridCellModel : MonoBehaviour
{
    private bool isOccupy;

    public bool IsOccupy => isOccupy;

    public void OccupyCell()
    {
        isOccupy = true;
    }

    public void FreeCell()
    {
        isOccupy = false;
    }
}
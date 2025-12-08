using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    public void Show()
    {
        canvas.enabled = true;
    }
}
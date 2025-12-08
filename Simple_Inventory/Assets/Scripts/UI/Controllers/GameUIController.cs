using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private GraphicRaycaster graphicRaycaster;

    public void Show()
    {
        canvas.enabled = true;
    }

    public void EnableUI()
    {
        graphicRaycaster.enabled = true;
    }
}
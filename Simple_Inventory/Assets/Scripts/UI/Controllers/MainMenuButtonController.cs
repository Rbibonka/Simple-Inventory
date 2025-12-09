using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField]
    private PointerDownObserver pointerDownObserver;

    [SerializeField]
    private PointerUpObserver pointerUpObserver;

    [SerializeField]
    private RectTransform txt_Text;

    private Vector3 startTextPosition;

    private const float OffsetY = 20f;

    private void Start()
    {
        startTextPosition = txt_Text.localPosition;

        pointerDownObserver.PointerDown += OnPointerDown;
        pointerUpObserver.PointerUp += OnPointerUp;
    }

    private void OnDestroy()
    {
        pointerDownObserver.PointerDown -= OnPointerDown;
        pointerUpObserver.PointerUp -= OnPointerUp;
    }

    private void OnPointerUp()
    {
        txt_Text.localPosition = startTextPosition;
    }

    private void OnPointerDown(PointerEventData obj)
    {
        var tempVector = txt_Text.localPosition;
        tempVector.y = tempVector.y - OffsetY;

        txt_Text.localPosition = tempVector;
    }
}
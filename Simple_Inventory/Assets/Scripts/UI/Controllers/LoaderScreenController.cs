using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public sealed class LoaderScreenController : MonoBehaviour
{
    [SerializeField]
    private RectTransform img_Screen;

    [SerializeField]
    private Vector2 startPosition;

    [SerializeField]
    private Vector2 endPosition;

    private LoaderScreenView loaderScreenView;

    public void Initialize()
    {
        loaderScreenView = new(img_Screen);
        startPosition = img_Screen.localPosition;
    }

    public async UniTask HideScreenAsync(CancellationToken ct)
    {
        await loaderScreenView.MoveScreenAsync(ct, endPosition, startPosition);
    }

    public async UniTask ShowScreenAsync(CancellationToken ct)
    {
        await loaderScreenView.MoveScreenAsync(ct, startPosition, endPosition);
    }
}
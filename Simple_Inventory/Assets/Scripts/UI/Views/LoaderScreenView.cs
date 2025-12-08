using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;

public class LoaderScreenView
{
    private RectTransform rectTransform;

    private const float moveDuration = 1f;

    public LoaderScreenView(RectTransform rectTransform)
    {
        this.rectTransform = rectTransform;
    }

    public async UniTask MoveScreenAsync(CancellationToken ct, Vector2 startPosition, Vector2 endPosition)
    {
        rectTransform.localPosition = startPosition;

        await rectTransform.DOLocalMove(endPosition, moveDuration).SetEase(Ease.InOutBounce);
    }
}
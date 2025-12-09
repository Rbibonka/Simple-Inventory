using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public sealed class MainMenuView
{
    private const int StartAnimationYPosition = 2000;

    private IReadOnlyDictionary<RectTransform, Vector3> buttonsTransforms;

    private IconController[] iconControllers;

    public MainMenuView(IReadOnlyDictionary<RectTransform, Vector3> buttonsTransforms, IconController[] iconControllers)
    {
        this.buttonsTransforms = buttonsTransforms;
        this.iconControllers = iconControllers;
    }

    public void ShowIcons()
    {
        foreach (var controller in iconControllers)
        {
            controller.Show();
        }
    }

    public async UniTask MoveButtonsAsync(CancellationToken ct)
    {
        foreach (var button in buttonsTransforms)
        {
            button.Key.localScale = Vector3.zero;
        }

        foreach (var button in buttonsTransforms)
        {
            await UniTask.WaitForSeconds(0.2f, cancellationToken: ct);

            _ = button.Key.DOScale(Vector3.one, 0.3f).SetEase(Ease.InSine);
        }
    }
}
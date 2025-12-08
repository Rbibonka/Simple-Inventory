using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

public sealed class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private RectTransform[] buttonsTransform;

    [SerializeField]
    private UIButtonObserver playButtonObserver;

    [SerializeField]
    private UIButtonObserver exitButtonObserver;

    [SerializeField]
    private MainMenuLoaderController mainMenuLoaderController;

    private MainMenuView mainMenuView;
    private MainMenuModel mainMenuModel;

    public event Action StartButtonClicked;

    public void Initialize()
    {
        playButtonObserver.ButtonClicked += OnPlayButtonClicked;
        exitButtonObserver.ButtonClicked += OnExitButtonClicked;

        mainMenuLoaderController.Initialize();

        mainMenuModel = new(canvas);
        mainMenuModel.SetButtonsPosition(buttonsTransform);

        mainMenuView = new(mainMenuModel.ButtonsTransfroms);
    }

    public async UniTask ShowAsync(CancellationToken ct)
    {
        await UniTask.WhenAll(mainMenuLoaderController.HideAsync(ct), mainMenuView.MoveButtonsAsync(ct));
    }

    public async UniTask HideAsync(CancellationToken ct)
    {
        await mainMenuLoaderController.ShowAsync(ct);
        mainMenuModel.DisableUI();
    }

    private void OnPlayButtonClicked()
    {
        StartButtonClicked?.Invoke();
    }

    private void OnExitButtonClicked()
    {

    }
}
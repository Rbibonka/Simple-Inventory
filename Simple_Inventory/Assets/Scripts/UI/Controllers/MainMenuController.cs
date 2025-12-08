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
    private IconController[] iconControllers;

    [SerializeField]
    private UIButtonObserver playButtonObserver;

    [SerializeField]
    private UIButtonObserver exitButtonObserver;

    private MainMenuLoaderController mainMenuLoaderController;

    private MainMenuView mainMenuView;
    private MainMenuModel mainMenuModel;

    public event Action StartButtonClicked;

    public void Initialize(MainMenuLoaderController mainMenuLoaderController)
    {
        this.mainMenuLoaderController = mainMenuLoaderController;

        playButtonObserver.ButtonClicked += OnPlayButtonClicked;
        exitButtonObserver.ButtonClicked += OnExitButtonClicked;

        mainMenuLoaderController.Initialize();

        foreach (var controller in iconControllers)
        {
            controller.Initialize();
        }

        mainMenuModel = new(canvas);
        mainMenuModel.SetUIElements(buttonsTransform);

        mainMenuView = new(mainMenuModel.ButtonsTransfroms, iconControllers);
    }

    public async UniTask ShowAsync(CancellationToken ct)
    {
        await UniTask.WhenAll(mainMenuLoaderController.HideAsync(ct), mainMenuView.MoveButtonsAsync(ct));
        mainMenuView.ShowIcons();
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
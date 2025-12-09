using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

public sealed class MainMenuController : MonoBehaviour, IDisposable
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

    private MainMenuView mainMenuView;
    private MainMenuModel mainMenuModel;

    public event Action StartButtonClicked;
    public event Action ExitButtonClicked;

    private bool isDisposed;

    public void Initialize()
    {
        playButtonObserver.ButtonClicked += OnPlayButtonClicked;
        exitButtonObserver.ButtonClicked += OnExitButtonClicked;

        foreach (var controller in iconControllers)
        {
            controller.Initialize();
        }

        mainMenuModel = new(canvas);
        mainMenuModel.SetUIElements(buttonsTransform);

        mainMenuView = new(mainMenuModel.ButtonsTransfroms, iconControllers);
    }

    public void Dispose()
    {
        if (isDisposed)
        {
            return;
        }

        playButtonObserver.ButtonClicked -= OnPlayButtonClicked;
        exitButtonObserver.ButtonClicked -= OnExitButtonClicked;

        isDisposed = true;
    }

    public async UniTask ShowAsync(CancellationToken ct)
    {
        await mainMenuView.MoveButtonsAsync(ct);
        mainMenuView.ShowIcons();
    }

    public void HideAsync()
    {
        mainMenuModel.DisableUI();
    }

    private void OnPlayButtonClicked()
    {
        StartButtonClicked?.Invoke();
    }

    private void OnExitButtonClicked()
    {
        ExitButtonClicked?.Invoke();
    }
}
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class MainMenuLoaderController : MonoBehaviour
{
    [SerializeField]
    private LoaderScreenController[] LoaderScreens;

    public void Initialize()
    {
        foreach (var loader in LoaderScreens)
        {
            loader.Initialize();
        }
    }

    public async UniTask ShowAsync(CancellationToken ct)
    {
        UniTask[] uniTasks = new UniTask[LoaderScreens.Length];

        for (int i = 0; i < LoaderScreens.Length; i++)
        {
            uniTasks[i] = LoaderScreens[i].ShowScreenAsync(ct);
        }

        await UniTask.WhenAll(uniTasks);
    }

    public async UniTask HideAsync(CancellationToken ct)
    {
        UniTask[] uniTasks = new UniTask[LoaderScreens.Length];

        for (int i = 0; i < LoaderScreens.Length; i++)
        {
            uniTasks[i] = LoaderScreens[i].HideScreenAsync(ct);
        }

        await UniTask.WhenAll(uniTasks);
    }
}
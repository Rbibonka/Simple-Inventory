using UnityEngine;

public sealed class IconController : MonoBehaviour
{
    [SerializeField]
    private new ParticleSystem particleSystem;

    [SerializeField]
    private RectTransform img_Image;

    private IconView iconView;

    public void Initialize()
    {
        iconView = new(particleSystem, img_Image);
        iconView.HideImmediately();
    }

    public void Show()
    {
        iconView.Show();
    }
}
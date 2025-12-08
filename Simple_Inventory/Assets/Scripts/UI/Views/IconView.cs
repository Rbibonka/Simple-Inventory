using DG.Tweening;
using UnityEngine;

public class IconView
{
    private ParticleSystem particleSystem;
    private RectTransform img_Image;

    public IconView(ParticleSystem particleSystem, RectTransform img_Image)
    {
        this.particleSystem = particleSystem;
        this.img_Image = img_Image;
    }

    public void HideImmediately()
    {
        img_Image.localScale = Vector3.zero;
    }

    public void Show()
    {
        particleSystem.Play();
        img_Image.DOScale(Vector3.one, 0.5f).SetEase(Ease.InOutBounce);
    }
}
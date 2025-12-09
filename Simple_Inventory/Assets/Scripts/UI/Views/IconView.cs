using DG.Tweening;
using UnityEngine;

public class IconView
{
    private ParticleSystem particleSystem;
    private RectTransform img_Image;

    private Vector3 startScale = Vector3.zero;
    private Vector3 endScale = Vector3.one;

    private const float scaleTime = 0.5f;

    public IconView(ParticleSystem particleSystem, RectTransform img_Image)
    {
        this.particleSystem = particleSystem;
        this.img_Image = img_Image;
    }

    public void HideImmediately()
    {
        img_Image.localScale = startScale;
    }

    public void Show()
    {
        particleSystem.Play();
        img_Image.DOScale(endScale, scaleTime).SetEase(Ease.InOutBounce);
    }
}
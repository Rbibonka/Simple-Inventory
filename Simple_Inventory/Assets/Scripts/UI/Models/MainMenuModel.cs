using System.Collections.Generic;
using UnityEngine;

public sealed class MainMenuModel
{
    private Canvas canvas;

    private Dictionary<RectTransform, Vector3> buttonsTransfroms;

    public IReadOnlyDictionary<RectTransform, Vector3> ButtonsTransfroms => buttonsTransfroms;

    public MainMenuModel(Canvas canvas)
    {
        this.canvas = canvas;
    }

    public void DisableUI()
    {
        canvas.enabled = false;
    }

    public void SetUIElements(RectTransform[] buttonsTransform)
    {
        buttonsTransfroms = new();

        foreach (var buttonTransform in buttonsTransform)
        {
            buttonsTransfroms.Add(buttonTransform, buttonTransform.position);
        }
    }
}
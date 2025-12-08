using System.Collections.Generic;
using UnityEngine;

public sealed class MainMenuModel
{
    private Dictionary<RectTransform, Vector3> buttonsTransfroms;

    public IReadOnlyDictionary<RectTransform, Vector3> ButtonsTransfroms => buttonsTransfroms;

    public void SetButtonsPosition(RectTransform[] buttonsTransform)
    {
        buttonsTransfroms = new();

        foreach (var buttonTransform in buttonsTransform)
        {
            buttonsTransfroms.Add(buttonTransform, buttonTransform.position);
        }
    }
}
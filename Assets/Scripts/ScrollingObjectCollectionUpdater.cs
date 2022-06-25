using Microsoft.MixedReality.Toolkit.UI;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScrollingObjectCollection))]
public class ScrollingObjectCollectionUpdater : MonoBehaviour
{

    private ScrollingObjectCollection soc;
    private GridObjectCollectionUpdater gocu;

    private void Awake()
    {
        soc = GetComponent<ScrollingObjectCollection>();
        gocu = GetComponentInChildren<GridObjectCollectionUpdater>();
    }

    public void AddButtons(List<ButtonSet.Button> buttons)
    {
        foreach (var button in buttons)
        {
            gocu.CreateButton(button.Id, button.Name, button.IconName);
        }
        gocu.UpdateCollection();
        soc.UpdateContent();
    }

    public void ClearButtons()
    {
        // soc.ClipBox.ClearRenderers();
        gocu.ClearButtons();
    }
}

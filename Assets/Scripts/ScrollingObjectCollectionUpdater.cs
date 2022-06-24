using Microsoft.MixedReality.Toolkit.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ScrollingObjectCollection))]
public class ScrollingObjectCollectionUpdater : MonoBehaviour
{
    [System.Serializable]
    public struct Button
    {
        public string Id;
        public string Name;
        public string IconName;

        public Button(string id, string name, string iconName)
        {
            Id = id;
            Name = name;
            IconName = iconName;
        }
    }

    private ScrollingObjectCollection soc;
    private GridObjectCollectionUpdater gocu;

    private void Awake()
    {
        soc = GetComponent<ScrollingObjectCollection>();
        gocu = GetComponentInChildren<GridObjectCollectionUpdater>();
    }

    public void AddButtons(List<Button> buttons)
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
        soc.ClipBox.ClearRenderers();
        gocu.ClearButtons();
    }
}

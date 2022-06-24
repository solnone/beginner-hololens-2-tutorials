using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GridObjectCollection))]
public class GridObjectCollectionUpdater : MonoBehaviour
{
    [SerializeField]
    private ButtonConfigHelper buttonPrefab;

    private GridObjectCollection goc;
    private readonly Dictionary<string, ButtonConfigHelper> buttons = new();

    private void Awake()
    {
        goc = GetComponent<GridObjectCollection>();
    }

    public void ClearButtons()
    {
        foreach (var button in buttons.Values)
        {
            Destroy(button.gameObject);
        }
        buttons.Clear();
    }

    public void CreateButton(string key, string name, string iconName)
    {
        var configHelper = Instantiate<ButtonConfigHelper>(buttonPrefab, transform);
        configHelper.gameObject.name = key;
        configHelper.MainLabelText = name;
        configHelper.SetQuadIconByName(iconName);
        buttons.Add(key, configHelper);
    }

    public void UpdateCollection()
    {
        goc.UpdateCollection();
    }

    public void AddTouchReceiverEventsByKey(string key, UnityAction touchStart, UnityAction touchEnd)
    {
        Interactable interactable = buttons[key].gameObject.GetComponent<Interactable>();
        var onTouchReceiver = interactable.GetReceiver<InteractableOnTouchReceiver>();
        if (onTouchReceiver == null)
        {
            onTouchReceiver = interactable.AddReceiver<InteractableOnTouchReceiver>();
        }
        onTouchReceiver.Event.AddListener(touchStart);
        onTouchReceiver.OnTouchEnd.AddListener(touchEnd);
        interactable.RefreshSetup();
    }

}

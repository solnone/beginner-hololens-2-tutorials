using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrollingObjectCollectionTest : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro message;
    [SerializeField]
    private TextMeshPro touchMessage;
    [SerializeField]
    private List<ScrollingObjectCollectionUpdater.Button> buttons;



    private ScrollingObjectCollectionUpdater updater;
    void Start()
    {
        updater = GetComponent<ScrollingObjectCollectionUpdater>();
        if (buttons.Count == 0)
        {
            Test();
        }
        else
        {
            updater.AddButtons(buttons);
        }
    }

    void AddButton(string key, string name, string iconName)
    {
        buttons.Add(new(key, name, iconName));
    }

    void ClearButtons()
    {
        updater.ClearButtons();
    }

    public void ShowMessage(GameObject button)
    {
        if (message)
        {
            var configHelper = button.GetComponent<ButtonConfigHelper>();
            message.text = $"ShowMessage: {configHelper.MainLabelText}";
        }
    }

    public void TouchStarted(GameObject button)
    {
        if (touchMessage)
        {
            var configHelper = button.GetComponent<ButtonConfigHelper>();
            touchMessage.text = $"TouchStarted: {configHelper.MainLabelText}";
        }
    }

    public void TouchEnded(GameObject button)
    {
        if (touchMessage)
        {
            var configHelper = button.GetComponent<ButtonConfigHelper>();
            touchMessage.text = $"TouchEnded: {configHelper.MainLabelText}";
        }
    }

    private void Test()
    {
        Invoke(nameof(AddIcons), 2.0f);
        Invoke(nameof(AddIcons2), 3.0f);
        Invoke(nameof(AddIcons), 5.0f);
        Invoke(nameof(AddIcons2), 6.0f);
        Invoke(nameof(AddIcons), 7.0f);
        Invoke(nameof(AddIcons2), 8.0f);
        Invoke(nameof(ClearButtons), 8.0f);
        Invoke(nameof(AddIcons), 15.0f);
        Invoke(nameof(AddIcons2), 16.0f);
        Invoke(nameof(AddIcons), 17.0f);
        Invoke(nameof(AddIcons2), 18.0f);
    }

    void AddIcons()
    {
        buttons.Clear();
        AddButton($"First {DateTime.Now:HH:mm:ss.fff}", "First", "IconClose");
        AddButton($"Second {DateTime.Now:HH:mm:ss.fff}", "Second", "IconDone");
        AddButton($"Third {DateTime.Now:HH:mm:ss.fff}", "Third", "IconHide");
        AddButton($"Fourth {DateTime.Now:HH:mm:ss.fff}", "Fourth", "IconShow");
        AddButton($"Fifth {DateTime.Now:HH:mm:ss.fff}", "Fifth", "IconFollowMe");
        AddButton($"Sixth {DateTime.Now:HH:mm:ss.fff}", "Sixth", "IconHandJoint");
        AddButton($"Seventh {DateTime.Now:HH:mm:ss.fff}", "Seventh", "IconHandMesh");
        updater.AddButtons(buttons);
    }

    void AddIcons2()
    {
        buttons.Clear();
        AddButton($"Eighth {DateTime.Now:HH:mm:ss.fff}", "Eighth", "IconHandRay");
        AddButton($"Ninth {DateTime.Now:HH:mm:ss.fff}", "Ninth", "IconHome");
        AddButton($"Tenth {DateTime.Now:HH:mm:ss.fff}", "Tenth", "IconPin");
        AddButton($"Eleventh {DateTime.Now:HH:mm:ss.fff}", "Eleventh", "IconProfiler");
        updater.AddButtons(buttons);
    }
}

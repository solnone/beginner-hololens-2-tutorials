using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ButtonSet", menuName = "ButtonSet")]
public class ButtonSet : ScriptableObject
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

    public Button[] buttons;

}

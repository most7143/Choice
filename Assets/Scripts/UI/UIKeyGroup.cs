using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeyGroup : MonoBehaviour
{
    public List<Image> KeyIcons;

    private void Start()
    {
        foreach (Image i in KeyIcons)
        {
            i.color = Color.black;
        }
    }

    public void RefreshKey(int count)
    {
        for (int i = 0; i < KeyIcons.Count; i++)
        {
            if (i < count)
            {
                KeyIcons[i].color = Color.white;
            }
        }
    }
}
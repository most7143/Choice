using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIChoice : MonoBehaviour
{
    public TextMeshProUGUI Text;

    public void SetText(string text)
    {
        Text.text = text;
    }
}
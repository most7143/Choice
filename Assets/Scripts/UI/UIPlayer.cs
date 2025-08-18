using TMPro;
using UnityEngine;

public class UIPlayer : MonoBehaviour
{
    public TextMeshProUGUI HPText;

    public void RefreshHP(int value)
    {
        HPText.text = value.ToString();
    }
}
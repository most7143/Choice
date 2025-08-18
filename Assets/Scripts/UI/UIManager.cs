using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    public UIPlayer PlayerUI;

    private void Awake()
    {
        instance = this;
    }
}
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public GameObject Space;

    public void Start()
    {
        HideSpace();
    }

    public void ShowSpace()
    {
        Space.gameObject.SetActive(true);
    }

    public void HideSpace()
    {
        Space.gameObject.SetActive(false);
    }
}
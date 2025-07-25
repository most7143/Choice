using UnityEngine;
using UnityEngine.UIElements;

public class UIChoice : MonoBehaviour
{
    public UIDocument Document;
    private Label Left;
    private Label Right;

    public void ShowRed(string text)
    {
        if (Left == null)
        {
            Left = Document.rootVisualElement.Q<Label>("RedLabel");
        }

        Left.text = text;
    }

    public void ShowBlue(string text)
    {
        if (Right == null)
        {
            Right = Document.rootVisualElement.Q<Label>("BlueLabel");
        }

        Right.text = text;
    }

    private void Update()
    {
    }
}
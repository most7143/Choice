using UnityEngine;
using UnityEngine.UIElements;

public class UIChoice : MonoBehaviour
{
    public UIDocument Document;
    private Label Left;
    private Label Right;

    private void Start()
    {
        Left = Document.rootVisualElement.Q<Label>("RedLabel");
        Right = Document.rootVisualElement.Q<Label>("BlueLabel");

        Left.text = "dd";
        Right.text = "22";
    }

    private void Update()
    {
    }
}
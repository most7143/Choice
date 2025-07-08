using UnityEngine;
using UnityEngine.UIElements;

public class UIFollow : MonoBehaviour
{
    public UIDocument Document;
    public Transform Target;

    private VisualElement labelContainer;

    public Vector2 Offset = new Vector2(0, 2f); // �ν����Ϳ��� ���� ����
    public Vector2 PivotOffset = new Vector2(0.5f, 0.5f); // �߽��� ���߱� ���� ���� ��

    private void Start()
    {
        labelContainer = Document.rootVisualElement.Q<VisualElement>("Space");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Target == null || labelContainer == null) return;

        Vector3 worldPos = Target.position + new Vector3(Offset.x, Offset.y, 0);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        float width = labelContainer.resolvedStyle.width;
        float height = labelContainer.resolvedStyle.height;

        labelContainer.style.left = screenPos.x - width * PivotOffset.x;

        labelContainer.style.top = Screen.height - screenPos.y - height * PivotOffset.y;
    }
}
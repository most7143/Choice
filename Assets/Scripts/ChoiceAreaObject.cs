using UnityEngine;

public class ChoiceAreaObject : MonoBehaviour
{
    public ChoiceSystem System;

    public int Index;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();

            if (player != null)
            {
                System.Index = Index;
                player.Interaction(true);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();

            if (player != null)
            {
                System.Index = 0;
                player.Interaction(false);
            }
        }
    }
}
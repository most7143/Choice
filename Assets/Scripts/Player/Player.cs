using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int MaxHealth = 10;
    public int CurrentHealth;
    public float MoveSpeed = 5f;
    public float DashSpeed = 30f;

    public PlayerInput Input;
    public InteractionObject InteractionObj;
    public Rigidbody2D Rigid;
    public Animator Anim;

    public bool IsInteraction;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        Input.Anim = Anim;
        Input.Rigid = Rigid;
        Input.MoveSpeed = MoveSpeed;
        Input.DashSpeed = DashSpeed;
    }

    public void RefreshHP(int value)
    {
        CurrentHealth += value;

        UIManager.Instance.PlayerUI.RefreshHP(CurrentHealth);
    }

    public void Interaction(bool isActivate)
    {
        IsInteraction = isActivate;

        if (isActivate)
        {
            InteractionObj.ShowSpace();
        }
        else
        {
            InteractionObj.HideSpace();
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 5f;

    public InteractionObject InteractionObj;
    public Rigidbody2D Rigid;
    public Animator Anim;

    public bool IsInteraction;
    public int KeyCount;
    private Vector2 moveInput;

    private List<KeyCode> inputQueue = new List<KeyCode>();
    private Vector2 moveDirection = Vector2.zero;
    private Vector2 lastMoveDirection = Vector2.down;

    private void Update()
    {
        HandleInput();
        AnimationMovement();
    }

    private void FixedUpdate()
    {
        Rigid.linearVelocity = moveDirection * MoveSpeed;
    }

    private void HandleInput()
    {
        KeyCode[] keys = { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow };

        foreach (var key in keys)
        {
            if (Input.GetKeyDown(key))
            {
                inputQueue.Remove(key);
                inputQueue.Add(key);
            }
            else if (Input.GetKeyUp(key))
            {
                inputQueue.Remove(key);
            }
        }

        if (inputQueue.Count > 0)
        {
            moveDirection = GetDirectionFromKey(inputQueue[inputQueue.Count - 1]);

            foreach (var key in keys)
            {
                if (false == Input.GetKey(key))
                {
                    inputQueue.Remove(key);
                }
            }
        }
        else
        {
            moveDirection = Vector2.zero;
        }
    }

    private Vector2 GetDirectionFromKey(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.UpArrow: return Vector2.up;
            case KeyCode.DownArrow: return Vector2.down;
            case KeyCode.LeftArrow: return Vector2.left;
            case KeyCode.RightArrow: return Vector2.right;
            default: return Vector2.zero;
        }
    }

    private void AnimationMovement()
    {
        if (moveDirection != Vector2.zero)
        {
            lastMoveDirection = moveDirection;
        }

        Anim.SetFloat("X", lastMoveDirection.x);
        Anim.SetFloat("Y", lastMoveDirection.y);

        Anim.SetBool("IsMoving", IsAnyMovementKeyHeld());
    }

    private bool IsAnyMovementKeyHeld()
    {
        return inputQueue.Count > 0;
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
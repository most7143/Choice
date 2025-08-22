using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public Animator Anim;
    [HideInInspector] public Rigidbody2D Rigid;
    [HideInInspector] public float MoveSpeed;

    public SkillSystem SkillSystem;

    private List<KeyCode> inputQueue = new List<KeyCode>();
    private Vector2 moveDirection = Vector2.zero;
    private Vector2 lastMoveDirection = Vector2.down;

    public bool IsDash
    { get { return SkillSystem.GetActivate(SkillNames.Dash); } }

    private void Update()
    {
        HandleInput();
        AnimationMovement();

        if (Input.GetKeyDown(KeyCode.S))
        {
            SkillSystem.OnSkill(SkillNames.Dash);
        }
    }

    private void FixedUpdate()
    {
        if (Rigid == null)
            return;

        if (false == IsDash)
        {
            Rigid.linearVelocity = moveDirection * MoveSpeed;
        }
        else
        {
            Rigid.linearVelocity = lastMoveDirection * SkillSystem.GetValue(SkillNames.Dash);
        }
    }

    public void HandleInput()
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

    public Vector2 GetDirectionFromKey(KeyCode key)
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

    public void AnimationMovement()
    {
        if (Anim == null)
            return;

        if (moveDirection != Vector2.zero && false == IsDash)
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
}
using System;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public SkillSystem System;
    public SkillNames Name;

    public UISkillIcon Icon;

    public float Value;

    public float ActivateTime;
    private float currentActivateTime;

    public bool IsCooldown;
    public float Cooldown;
    private float currentCooldown;

    public bool IsActivate;

    public void OnSkill()
    {
        IsActivate = true;

        if (currentCooldown <= 0)
        {
            currentActivateTime = ActivateTime;
            currentCooldown = Cooldown;
        }
    }

    public void Deactivate()
    {
        IsActivate = false;
        System.Deactivate(Name);
    }

    public void Logic()
    {
        if (currentActivateTime > 0)
        {
            currentActivateTime -= Time.deltaTime;

            if (currentActivateTime < 0)
            {
                Deactivate();
            }
        }

        if (currentCooldown > 0)
        {
            IsCooldown = true;
            currentCooldown -= Time.deltaTime;

            Icon.CooldownImage.fillAmount = currentCooldown / Cooldown;
        }
        else
        {
            IsCooldown = false;
        }
    }
}
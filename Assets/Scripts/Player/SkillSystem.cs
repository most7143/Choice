using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public Player Player;

    public PlayerParticle PlayerParticle;

    public List<PlayerSkill> Skills;

    private List<PlayerSkill> _learnSkills = new();

    private void Start()
    {
        Learn(SkillNames.Dash);
    }

    public void Learn(SkillNames skillName)
    {
        for (int i = 0; i < Skills.Count; i++)
        {
            if (Skills[i].Name == skillName)
            {
                if (false == _learnSkills.Contains(Skills[i]))
                {
                    _learnSkills.Add(Skills[i]);
                    break;
                }
            }
        }
    }

    public void Update()
    {
        for (int i = 0; i < _learnSkills.Count; i++)
        {
            _learnSkills[i].Logic();
        }
    }

    public void OnSkill(SkillNames name)
    {
        for (int i = 0; i < _learnSkills.Count; i++)
        {
            if (_learnSkills[i].Name == name && false == _learnSkills[i].IsActivate && false == _learnSkills[i].IsCooldown)
            {
                _learnSkills[i].OnSkill();
                StartParicle(name);
            }
        }
    }

    private void StartParicle(SkillNames name)
    {
        if (name == SkillNames.Dash)
        {
            PlayerParticle.StartDashParticle();
        }
    }

    public void Deactivate(SkillNames name)
    {
        if (name == SkillNames.Dash)
        {
            PlayerParticle.StopDashParticle();
        }
    }

    public float GetValue(SkillNames name)
    {
        for (int i = 0; i < _learnSkills.Count; i++)
        {
            if (_learnSkills[i].Name == name)
            {
                return _learnSkills[i].Value;
            }
        }

        return 0f;
    }

    public bool GetActivate(SkillNames name)
    {
        for (int i = 0; i < _learnSkills.Count; i++)
        {
            if (_learnSkills[i].Name == name)
            {
                return _learnSkills[i].IsActivate;
            }
        }

        return false;
    }
}
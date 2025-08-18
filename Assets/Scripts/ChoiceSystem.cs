using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChoiceSystem : MonoBehaviour
{
    public List<ChoiceData> Datas;

    public Player Player;

    public UIKeyGroup KeyGroup;

    public UIChoice RedChoice;
    public UIChoice BlueChoice;

    private ChoiceData _currentChoiceData;

    public int Level = 0;
    public int Key = 0;

    public int Index = -1;

    public void Start()
    {
        RerollChoice();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Player.IsInteraction)
            {
                Choice(Index);
            }
        }
    }

    public void RerollChoice()
    {
        int rand = Random.Range(0, Datas.Count);

        SetChoice(Datas[rand]);
    }

    public void SetChoice(ChoiceData data)
    {
        string redText = string.Format(data.Description, data.Chances[0] * 100, data.RewardValues[0]);
        string blueText = string.Format(data.Description, data.Chances[1] * 100, data.RewardValues[1]);

        RedChoice.SetText(redText);
        BlueChoice.SetText(blueText);
        _currentChoiceData = data;
    }

    public void Choice(int index)
    {
        if (_currentChoiceData.Condition == ChoiceConditions.Chance)
        {
            float rand = Random.Range(0, 1f);
            if (rand <= _currentChoiceData.Chances[index])
            {
                GetReward(_currentChoiceData.Reward, _currentChoiceData.RewardValues[index]);
            }
        }

        RerollChoice();
    }

    public void GetReward(ChoiceRewards reward, float value)
    {
        if (reward == ChoiceRewards.Key)
        {
            Key += (int)value;
        }
        else if (reward == ChoiceRewards.HP)
        {
            Player.RefreshHP((int)value);
        }

        RefreshUI(reward);
    }

    public void RefreshUI(ChoiceRewards reward)
    {
        if (reward == ChoiceRewards.Key)
        {
            KeyGroup.RefreshKey(Key);
        }
    }
}
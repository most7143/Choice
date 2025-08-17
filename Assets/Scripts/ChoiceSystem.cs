using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChoiceSystem : MonoBehaviour
{
    public List<ChoiceData> Datas;

    public Player Player;

    private ChoiceData _currentChoiceData;

    public int Level = 0;
    public int Key = 0;

    public int Index = -1;

    public void Start()
    {
        SetChoice(Datas[0]);
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

    public void SetChoice(ChoiceData data)
    {
        string redText = string.Format(data.Description, data.Chances[0] * 100, data.RewardValues[0]);
        string blueText = string.Format(data.Description, data.Chances[1] * 100, data.RewardValues[1]);

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
    }

    public void GetReward(ChoiceRewards reward, float value)
    {
        if (reward == ChoiceRewards.Key)
        {
            Key += (int)value;
        }

        RefreshUI(reward);
    }

    public void RefreshUI(ChoiceRewards reward)
    {
    }
}
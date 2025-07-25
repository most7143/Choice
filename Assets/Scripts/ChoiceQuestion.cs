using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Choice")]
public class ChoiceData : ScriptableObject
{
    public ChoiceNames Name;
    public string Description;
    public ChioceTiers Tier;
    public ChoiceConditions Condition;
    public List<float> Chances;
    public ChoiceRewards Reward;
    public List<float> RewardValues;
}
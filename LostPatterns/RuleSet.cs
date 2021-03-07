using System;
using System.Collections.Generic;
using UnityEngine;

// Experimental AI Utility prototype.

[Serializable]
public class Rule
{
    public float value;
    public float goal;
    public AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);
    public float distance;
    public float evaluation;

    public Rule(float goal)
    {
        this.goal = goal;
    }

    public void Set(float value)
    {
        this.value = value;
        distance = Mathf.Abs(goal - value);
        evaluation = curve.Evaluate(value / goal);
    }
}

public class RuleSet
{
    public List<Rule[]> ruleSet = new List<Rule[]>();
    public List<Action> actionSet = new List<Action>();

    private int lastExecutedId = -1;

    public void Bind(Rule[] rule, Action action)
    {
        ruleSet.Add(rule);
        actionSet.Add(action);
    }

    public void Update()
    {
        var id = -1;
        var value = -1f;

        for (int i = 0; i < ruleSet.Count; i++)
        {
            var rules = ruleSet[i];

            var median = 0f;
            for (int j = 0; j < rules.Length; j++)
                median += rules[j].evaluation;
            median /= rules.Length;

            if (median > value)
            {
                id = i;
                value = median;
            }
        }

        if (id < 0)
            return;

        if (lastExecutedId != id && actionSet[id] != null)
        {
            lastExecutedId = id;
            actionSet[id]();
        }
    }
}
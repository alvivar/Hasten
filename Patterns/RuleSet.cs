using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Rule
{
    public float value;
    public float goal;
    public AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);

    public Rule(float goal)
    {
        this.goal = goal;
    }

    public void Set(float value)
    {
        this.value = value;
    }
}

public class RuleSet
{
    public List<Rule[]> ruleSet = new List<Rule[]>();
    public List<Action> actionSet = new List<Action>();

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
            {
                var rule = rules[j];
                var evaluation = rule.curve.Evaluate(rule.value / rule.goal);

                median += evaluation;
            }
            median /= rules.Length;

            if (median > value)
            {
                id = i;
                value = median;
            }
        }

        if (id < 0)
            return;

        if (actionSet[id] != null)
            actionSet[id]();
    }
}
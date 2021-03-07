using System;
using System.Collections.Generic;

public class StateMachine<TLabel>
{
    private class State
    {
        public readonly TLabel label;
        public readonly Action onStart;
        public readonly Action onStop;
        public readonly Action onUpdate;

        public State(TLabel label, Action onStart, Action onUpdate, Action onStop)
        {
            this.onStart = onStart;
            this.onUpdate = onUpdate;
            this.onStop = onStop;
            this.label = label;
        }
    }

    private readonly Dictionary<TLabel, State> stateDictionary;
    private State currentState;

    public TLabel CurrentState
    {
        get { return currentState.label; }

        set { ChangeState(value); }
    }

    public StateMachine()
    {
        stateDictionary = new Dictionary<TLabel, State>();
    }

    public void Update()
    {
        if (currentState != null && currentState.onUpdate != null)
            currentState.onUpdate();
    }

    public void AddState(TLabel label, Action onStart, Action onUpdate, Action onStop)
    {
        stateDictionary[label] = new State(label, onStart, onUpdate, onStop);
    }

    public void AddState(TLabel label, Action onStart, Action onUpdate)
    {
        AddState(label, onStart, onUpdate, null);
    }

    public void AddState(TLabel label, Action onStart)
    {
        AddState(label, onStart, null);
    }

    public void AddState(TLabel label)
    {
        AddState(label, null);
    }

    public void AddState<TSubStateLabel>(
        TLabel label,
        StateMachine<TSubStateLabel> subMachine,
        TSubStateLabel subMachineStartState)
    {
        AddState(
            label,
            () => subMachine.ChangeState(subMachineStartState),
            subMachine.Update);
    }

    private void ChangeState(TLabel newState)
    {
        if (currentState != null && currentState.onStop != null)
            currentState.onStop();

        currentState = stateDictionary[newState];

        if (currentState.onStart != null)
            currentState.onStart();
    }

    public override string ToString()
    {
        return CurrentState.ToString();
    }
}
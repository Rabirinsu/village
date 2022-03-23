using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    public List<State> transitions;

    public abstract bool ExitState(StateController monster);
    public abstract void ExecuteState(StateController monster);
    public abstract bool CheckRules(StateController monster);


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharState : ScriptableObject
{
    public List<CharState> transitions;

    public abstract bool ExitState(CharStateController PlayerStateController);
    public abstract void ExecuteState(CharStateController PlayerStateController);
    public abstract bool CheckRules(CharStateController PlayerStateController);


}

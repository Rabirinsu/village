using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStateController : MonoBehaviour
{
    
    public CharState currentState;
    public Spell spell;
    [HideInInspector] public Animator animator;
    [HideInInspector] public CharachterController CharController;
    void Start()
    {
        animator = GetComponent<Animator>();
        CharController = GetComponent<CharachterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState.ExitState(this))
        {
            UpdateState();
            Debug.Log("CHAR UPDATE State");
        }
        currentState.ExecuteState(this);

    }
    public void UpdateState()
    {

        foreach (var state in currentState.transitions) // Check every state transitions rules
        {

            if (state.CheckRules(this))
                currentState = state;
        }
    }
}

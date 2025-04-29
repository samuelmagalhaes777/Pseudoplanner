using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities.UniversalDelegates;
using Unity.VisualScripting;
using UnityEngine;

public class PseudoPlanner : MonoBehaviour
{

    public string PlanName;
    [SerializeField] int index;
    public BotMotor botMotor; // the bot's state machine that controls the actions
    public AIFlags flags; // the flags that will be checked in the plan's monitor functions
    public PseudoPlannerBasePlan curPlan;
    PseudoPlannerBasePlan defaultPlan = new PlanIdle();

    void Start()
    {
        botMotor = GetComponent<BotMotor>(); // Assumes there's a State Machine component attached

        //Setting up the entry plan 
        curPlan = defaultPlan;
        curPlan.planner = this;
        curPlan.Enter();
        PlanName = curPlan.ToString();
        index = curPlan.index;
    }

    //Monitoring the advance/retreat/break out conditions
    void FixedUpdate()
    {
        curPlan.Run();
        curPlan.MonitorAdvance();
        curPlan.MonitorBreak();

        index = curPlan.index;
    }


    //External function to switch the plans
    public void SwitchPlan(PseudoPlannerBasePlan plan)
    {
        curPlan.Exit();
        ResetDelays();
        
        curPlan = plan;
        curPlan.planner = this;
        curPlan.Enter();
        
        PlanName = curPlan.ToString();
    }

    private List<Coroutine> delayCoroutines = new List<Coroutine>();
    private Dictionary<Action, Coroutine> activeDelays = new Dictionary<Action, Coroutine>();

    public void Delay(float time, Action callback)
    {
        if (activeDelays.ContainsKey(callback))
            return;

        var delayCoroutine = StartCoroutine(DelayCoroutine(time, callback));
        delayCoroutines.Add(delayCoroutine);
        activeDelays[callback] = delayCoroutine;
    }

    IEnumerator DelayCoroutine(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback?.Invoke();

        if (activeDelays.ContainsKey(callback))
        {
            delayCoroutines.Remove(activeDelays[callback]);
            activeDelays.Remove(callback);
        }
    }

    public void ResetDelays()
    {
        foreach (var coroutine in delayCoroutines)
            StopCoroutine(coroutine);

        delayCoroutines.Clear();
        activeDelays.Clear();
    }
}
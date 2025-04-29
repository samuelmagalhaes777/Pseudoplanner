using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Unity.Entities.UniversalDelegates;
using UnityEngine;

public abstract class PseudoPlannerBasePlan 
{
    #region plan handling
    public PseudoPlanner planner;
    protected List<BotBaseState> States;
    public List<List<Func<bool>>> AdvanceConditions;
    public int index;
    
    public abstract void MonitorBreak();
    public abstract void Exit();
    
    public virtual void Enter()
    {
        index = 0;
        planner.botMotor.SwitchState(States[0]);
        planner.ResetDelays();
    }
    public virtual void Run()
    {
        
    }
    
    public virtual void MonitorAdvance()
    {
        if (AllTrue(AdvanceConditions[index]))
            GoNextStep();
    }
   
    protected void GoNextStep()
    {
        index += 1;
        planner.botMotor.SwitchState(States[index]);
    }
  
    protected bool AllTrue(List<Func<bool>> Conditions)
    {
        if (Conditions.Any())
            return Conditions.All(x => x());
        else return false;
    }
   
    protected bool ConditionsSuccesful(int i)
    {
        return index == i && AllTrue(AdvanceConditions[i]);
    }
     
    #endregion
    
}
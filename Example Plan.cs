using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities.UniversalDelegates;
using System;
public class PlanFlank : PseudoPlannerBasePlan
{
    int prevhealth;
    int waypointIndex = 0;
    Vector3[] waypoints;
    public override void Enter()
    {
        var path = planner.TargetManager.FlankPath();
        if (path == null)
        {
            planner.SwitchPlan(new PlanInvestigate());
            return;
        }
        Debug.Log(planner.gameObject.name + " is flanking!");
        waypoints = path;
        waypoints[2] = planner.TargetManager.Target.position;
        
        States = new List<BotBaseState>()
        {
               new BotWalkTowards(),
               new BotWalkTowards(),
               new BotWalkTowardsTarget(),
        };
        AdvanceConditions = new List<List<Func<bool>>>()
        {
             new ()
             {
                () => planner.flags.CloserThan(waypoints[0], 0.5f)
             },
             new ()
             {
                () => planner.flags.CloserThan(waypoints[1], 0.5f)
             },
             new (),
        };
        base.Enter();
        prevhealth = planner.flags.hitboxManager.Health;
        planner.botMotor.WalkPoint = waypoints[waypointIndex];
    }
    public override void Run()
    {
        base.Run();
        AutoEvaluateFiringMode();
    }
    public override void MonitorAdvance()
    {
        if (ConditionsSuccesful(0))
        {
            waypointIndex += 1;
            planner.botMotor.WalkPoint = waypoints[waypointIndex];
        }
        base.MonitorAdvance();
    }
    
    public override void Exit()
    {
    }
    
    public override void MonitorBreak()
    {
        if (index == 2 && planner.flags.CloserThan(planner.TargetManager.Target, 10f))
        {
            planner.SwitchPlan(new PlanCombat());
        }
    }
}
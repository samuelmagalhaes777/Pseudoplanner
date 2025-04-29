using System;
using Unity.Entities.UniversalDelegates;
using UnityEngine;

public class AIFlags : MonoBehaviour
{

    public enum Personalities
    {
        Overconfident,
        Coward,
        Sneaky,
    }

    public Personalities personality;

    [Space(15)]

    public HitboxManager hitboxManager;
    [SerializeField] BotTargetManager botTargetManager;

    public enum SeeModes
    {
        Normal,
        Hitboxes
    }

    public bool LowHealth => hitboxManager.Health < 50f;
    public bool TakenDamage(int Prev, int Amount)
    {
        return hitboxManager.Health < Prev - Amount;
    }

    public bool TargetTookDamage(int Prev, int Amount)
    {
        if (botTargetManager.PrevTarget.TryGetComponent(out HitboxManager targetHitboxManager))
            return targetHitboxManager.Health < Prev - Amount;
        else return false;
    }

    public bool CloserThan(object Target, float distance)
    {
        if (Target == null) return false;

        Type t = Target.GetType();
        if (t == typeof(Transform))
        {
            Transform targetAsTransform = (Transform)Target;
            return Vector3.Distance(targetAsTransform.position, transform.position) < distance;
        }
        else
        {
            return Vector3.Distance((Vector3)Target, transform.position) < distance;
        }
    }

    public bool FartherThan(object Target, float distance)
    {
        if (Target == null) return false;

        Type t = Target.GetType();
        if (t == typeof(Transform))
        {
            Transform targetAsTransform = (Transform)Target;
            return Vector3.Distance(targetAsTransform.position, transform.position) > distance;
        }
        else
        {
            return Vector3.Distance((Vector3)Target, transform.position) > distance;
        }
    }

    public bool CanSee(Transform Target, Vector3 reference = default, SeeModes seeMode = SeeModes.Normal)
    {
        if (Target == null) return false;

        LayerMask mask = botTargetManager.SeeMask;

        if (reference == default)
        {
            // If no custom reference is provided, use the bot's aiming position 
            reference = botTargetManager.Aimer.position;
        }
        else
        {
            // If a custom reference is provided, include the bot's own layer in the mask
            mask |= 1 << LayerMask.NameToLayer("NPCBox");
            mask |= 1 << LayerMask.NameToLayer("NPCBounds");
        }

        LayerMask seemask = seeMode == SeeModes.Normal ? mask : GetComponent<BotWeaponManager>().mask;
        var targetCenter = Target.TryGetComponent(out Collider col) ? col.bounds.center : Target.transform.position;

        Debug.DrawRay(reference, targetCenter - reference, Color.yellow);

        if (Physics.Raycast(reference, targetCenter - reference, out RaycastHit hit, Vector3.Distance(reference,targetCenter), seemask))
        {
            if (hit.collider.transform == Target || hit.collider.transform.IsChildOf(Target))
                return true;
            else return false;
        }
        return true;
    }

}

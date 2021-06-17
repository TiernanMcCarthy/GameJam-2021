using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingState : State
{
    
    public override void Execute(StateObject s)
    {
        
        
        Punter temp = s.GetComponent<Punter>();
        
        if (temp != null)
        {
            temp.Rig.velocity = Vector3.zero;
            DesirabilityBrain desirabilityBrain = new DesirabilityBrain(temp);

            // Debug.Log(desirabilityBrain.ThrowBottleDesirability());

            if (desirabilityBrain.ThrowBottleDesirability() > temp.ThrowLiklihood)
            {
                temp.FindTarget();
                if (temp.Victim != null)
                {
                    temp.tp.target = temp.Victim.gameObject;
                    temp.tp.yeetItem = true;
                    temp.SetThrowTime();
                }
            }


            if (temp.Happiness == 0 || temp.Angriness == 20)
            {
                temp.SatDown = false;
                temp.CurrentState = new LeaveState();
                //t
                //Leave lmao
            }
        }
        // throw new System.NotImplementedException();
    }
}

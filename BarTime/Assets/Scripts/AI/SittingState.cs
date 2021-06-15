using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingState : State
{

    public override void Execute(StateObject s)
    {
        

        Punter temp = s.GetComponent<Punter>();

        DesirabilityBrain desirabilityBrain = new DesirabilityBrain(temp);

       // Debug.Log(desirabilityBrain.ThrowBottleDesirability());

        if (desirabilityBrain.ThrowBottleDesirability() > temp.ThrowLiklihood)
        {
            temp.FindTarget();
            Debug.Log("I AM THROWING A FUCKING BOTTLE");
            temp.tp.target = temp.Victim.gameObject;
            temp.tp.yeetItem = true;
            temp.SetThrowTime();
        }
        // throw new System.NotImplementedException();
    }
}

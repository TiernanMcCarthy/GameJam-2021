using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Evaluate What the next state should be depending on class
public class Evaluate : State
{

    public override void Execute(StateObject s)
    {

        if(s.GetComponent<Punter>())
        {
            Punter temp = s.GetComponent<Punter>();

            DesirabilityBrain desirabilityBrain = new DesirabilityBrain(temp);

            //Come back here but calculate what he should do next



        }




    }



}

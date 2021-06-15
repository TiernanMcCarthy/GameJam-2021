using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Largest
{
    public int Index;
    public float Size;
    public Largest(int ind, float s)
    {
        Index = ind;
        Size = s;
    }

}
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

                List<Largest> Value = new List<Largest>();

                desirabilityBrain.Check();
                
                if(desirabilityBrain.GetCheeseDesire>0.5f)
                {
                    temp.MoveToLocation=temp.Target.transform.position;
                    temp.CurrentState = new Move();
                }



        }




    }



}

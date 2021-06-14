using UnityEngine;
public class Move : State
{
    private float MaxDistance = 0.3f;
    public override void Execute(StateObject s)
    {
        Vector2 temp = new Vector2(s.transform.position.x, s.transform.position.y);
        if (Vector2.Distance(temp, s.MoveToLocation) > MaxDistance)
        {

            if (s.Move())
            {
                temp =  s.MoveToLocation- temp;
                s.Rig2D.velocity = temp.normalized * s.BaseSpeed;


            }

        }
        else
        {
            s.Rig2D.velocity = Vector2.zero;
            s.CurrentState = new Evaluate();
        }


    }


}

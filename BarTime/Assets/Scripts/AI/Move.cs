using UnityEngine;
public class Move : State
{
    private float MaxDistance = 0.3f;
    public override void Execute(StateObject s)
    {
        //Vector2 temp = new Vector2(s.transform.position.x, s.transform.position.y);
       // Debug.Log(Vector2.Distance(temp, s.MoveToLocation));
        if (Vector3.Distance(s.transform.position, s.MoveToLocation) > MaxDistance)
        {

            if (s.Move())
            {
                Vector3 temp =  s.MoveToLocation- s.transform.position;
                s.Rig.velocity = temp.normalized * s.GetComponent<Punter>().Speed;


            }

        }
        else
        {
            s.Rig.velocity = Vector2.zero;
            s.CurrentState = new Evaluate();
        }


    }


}

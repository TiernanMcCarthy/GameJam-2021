using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveState : State
{

    public override void Execute(StateObject s)
    {
        Punter temp = s.GetComponent<Punter>();

        ManagerMan local = GameObject.FindObjectOfType<ManagerMan>();
        temp.MoveToLocation = local.Exit.transform.position;
        temp.Target = local.Exit;
        temp.Rig.isKinematic = false;
        temp.CurrentState = new Move();


    }

}

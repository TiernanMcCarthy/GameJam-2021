using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveState : State
{
    public float Multiplier = 2.5f;
    public override void Execute(StateObject s)
    {
        Punter temp = s.GetComponent<Punter>();

        ManagerMan local = GameObject.FindObjectOfType<ManagerMan>();
        temp.MoveToLocation = local.Exit.transform.position;
        temp.Target = local.Exit;
        temp.SitIn.Occupied = false;
        temp.Rig.isKinematic = false;
        temp.CurrentState = new Move();
        if (temp.NumberOfCheeseToSatisfy <= 0)
        {
            temp.SitIn.DropMoney(temp.Generosity * Multiplier);
        }
        temp.SitIn.Owner.inhabitantList.Remove(temp);
        temp.SitIn = null;
    }

}

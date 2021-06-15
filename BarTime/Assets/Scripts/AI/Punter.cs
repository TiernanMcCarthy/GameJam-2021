using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punter : StateObject
{

    [Header("Basic Attributes")]
    public float Health = 100;
    public float Speed = 5.0f;
    public float Damage = 10;


    [Header("Personality")]
    public float Intelligence = 5;
    public float Toxicity = 10;
    public float Empathy = 10;
    public float Generosity = 10;

    [Header("Perishables")]
    public float Hunger = 100;
    public float Drunkenness = 100;

    public Punter Victim;

    public Chair SitIn;
    public void Start()
    {
        BaseSpeed = Speed;
        CurrentState = new Move();
        Rig = GetComponent<Rigidbody>();
    }


    public StateObject Target;


    public void Update()
    {
        Debug.Log(CurrentState);
        if (Active)
        {
            CurrentState.Execute(this);
        }


    }

    public void FixedUpdate()
    {
        if (Target != null)
        {
            if (Target.GetComponent<Chair>())
            {
                if (Target.GetComponent<Chair>().Occupied)
                {
                    CurrentState = new Evaluate();
                }
                Debug.Log("WHNSAFHSAFHSAF");
                if (Vector3.Distance(transform.position, Target.transform.position) <= 2.0f)
                {
                    transform.position = Target.transform.position + Vector3.up * 2;
                    Rig.velocity = new Vector3(0, 0, 0);
                    Rig.isKinematic = true;
                    Target.GetComponent<Chair>().Occupied = true;
                    Target = null;
                    CurrentState = new SittingState();
                }
            }

            

        }

    }

    public override bool Move()
    {
        if(CanMove)
        {
            return true;
        }

        return false;
    }

}

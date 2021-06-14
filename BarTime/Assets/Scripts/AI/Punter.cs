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
    public void Start()
    {
        BaseSpeed = Speed;
        CurrentState = new Move();
        Rig2D = GetComponent<Rigidbody2D>();
    }


    public StateObject Target;


    public void Update()
    {
        if (Active)
        {
            CurrentState.Execute(this);
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

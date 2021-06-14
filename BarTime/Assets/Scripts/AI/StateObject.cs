using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public abstract class StateObject : MonoBehaviour //abstract class for executing states
{

    //public Character Target;

    public bool Active = false;
    public bool CanMove = true;
    public Vector2 MoveToLocation;
    public State CurrentState;
    public Rigidbody2D Rig2D;
    public float BaseSpeed;

    public abstract bool Move();

    private void Start()
    {
        Rig2D = GetComponent<Rigidbody2D>();
    }

    //  public Vehicle TargetObject;
    //public bool Team; //red is false, blue is true
    //public abstract Vehicle Target(List<Vehicle> t);

    // public abstract void SetParentTarget(Vehicle t); 
}
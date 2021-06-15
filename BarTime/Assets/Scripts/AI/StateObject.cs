using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public abstract class StateObject : MonoBehaviour //abstract class for executing states
{

    //public Character Target;

    public bool Active = false;
    public bool CanMove = true;
    public Vector3 MoveToLocation;
    public State CurrentState;
    public Rigidbody Rig;
    public float BaseSpeed;

    public abstract bool Move();

    private void Start()
    {
        Rig = GetComponent<Rigidbody>();
    }

    //  public Vehicle TargetObject;
    //public bool Team; //red is false, blue is true
    //public abstract Vehicle Target(List<Vehicle> t);

    // public abstract void SetParentTarget(Vehicle t); 
}
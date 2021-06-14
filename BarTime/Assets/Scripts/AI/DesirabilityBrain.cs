using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesirabilityBrain
{

    private Punter MainActor;

    private Punter SecondaryActor;

    //Punter Specific Actions
    public float GetBottleThrowDesire;
    public float GetCheeseDesire;
    public float GetFightDesire;

    public const float k = 0.5f; //Limiter on these desireability values in an attempt to keep them within meaningful range


    public DesirabilityBrain(Punter Actor,Punter SecondActor)
    {
        MainActor = Actor;
        SecondaryActor = SecondActor;
    }

    public DesirabilityBrain(Punter Actor)
    {
        MainActor = Actor;
    }


}

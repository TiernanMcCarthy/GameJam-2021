using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Dist
{
    public int Index;
    public Chair Sample;
    public Dist(int ind, Chair s)
    {
        Sample = s;
        Index = ind;
    }

}

public class DesirabilityBrain
{
    private Chair DebugChair;
    private Punter MainActor;

    private Punter SecondaryActor;

    //Punter Specific Actions
    public float GetBottleThrowDesire;
    public float GetCheeseDesire;
    public float GetFightDesire;

    private float MaximumHealth = 100;

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


    public float ThrowBottleDesirability()
    {
        float Value = 0;

        float Limiter = 0.04f;

        Value += (MainActor.Angriness-10) * Limiter;

        Value += (10-MainActor.Hunger) * Limiter;

        Value += (10-MainActor.Happiness) * Limiter;

        if(MainActor.TimeSinceThrowing()<MainActor.ThrowInterval)
        {
            Value = 0;
        }

        if (!MainActor.SatDown)
        {
            Value = 0;
        }
        MainActor.Damage = Value;
        return Value;


    }



    public float DistanceFromChair()
    {
        

        Collider[] hitList = Physics.OverlapSphere(MainActor.transform.position, 30);
        List<Dist> ClosestPositions = new List<Dist>();
        for (int i = 0; i < hitList.Length; i++)
        {
            if (hitList[i].gameObject != MainActor.gameObject && hitList[i].gameObject.GetComponent<Chair>())
            {
                if (MainActor != null)
                {
                    //Debug.Log("GISAihjsafhjsafhjsafhsaf");
                    if (hitList[i].gameObject.GetComponent<Chair>().Owner==null)
                    {
                        Debug.Log("SFhsafbhsfgahbsafhj");
                    }
                
                    if (hitList[i].gameObject.GetComponent<Chair>().Occupied == false && hitList[i].gameObject.GetComponent<Chair>().Owner.Team == MainActor.Team)
                    {
                        Dist Close = new Dist(i, hitList[i].gameObject.GetComponentInParent<Chair>());
                        ClosestPositions.Add(Close);
                    }
                 }
                    //Debug.Log("HEosafjsafhnsafhjsaf");
            }
        }
        if (ClosestPositions.Count != 0)
        {

            if (ClosestPositions.Count > 1)
            {
                for (int i = 0; i < ClosestPositions.Count - 1; i++) //Iterate through these and find the closest position by sorting
                {


                    if (Vector3.Distance(ClosestPositions[i].Sample.transform.position, MainActor.transform.position) > Vector3.Distance(ClosestPositions[i + 1].Sample.transform.position, MainActor.transform.position))
                    {
                        Dist temp = ClosestPositions[i];
                        ClosestPositions[i] = ClosestPositions[i + 1]; //Swap these positions
                        ClosestPositions[i + 1] = temp;
                        i = -1; //Reiterate
                    }

                }
            }
            // SetVehicle(hitList[ClosestPositions[0].Index].gameObject); //set the target vehicle
            MainActor.Target = ClosestPositions[0].Sample;
            return Vector3.Distance(ClosestPositions[0].Sample.transform.position, MainActor.transform.position);
        }

        //DebugChair.tag = "NAHHH MATE";
        MainActor.SelfDestruct();
        return 999999;
    }
        private float HealthStatus(Punter punter)
    {
        if(punter.Health>=MaximumHealth)
        {
            return 1;
        }


        return punter.Health / MaximumHealth;
    }


    public void Check()
    {

        GetCheeseDesire = ((1 - HealthStatus(MainActor)) / Mathf.Pow(DistanceFromChair(), 2))*100;

        //Debug.Log(GetCheeseDesire);

    }

}

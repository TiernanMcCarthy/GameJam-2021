using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punter : StateObject
{

    public static float BasicDecayAmount = 0.03f;


    [Header("Basic Attributes")]
    public float Health = 100;
    public float Speed = 5.0f;
    public float Damage = 10;
    public bool SatDown = false;
    public bool Team = false;   //False one, True the other


    [Header("Personality")]
    public float Happiness = 10;
    public float Angriness = 10;
    public float Generosity = 10;
    public float Patience = 10;

    [Header("Cheese Moods")]
    public float Intelligence = 10;
    public float Strength = 10;
    public float SpeedCheese = 10;
    public float Charisma = 10;



    [Header("Perishables")]
    public float Hunger = 100;
    public float Drunkenness = 100;
    public float TimeBetweenDecay = 3.0f;
    public float ThrowInterval = 10;
    public float ThrowLiklihood = 0.6f;

    public Punter Victim;

    public Chair SitIn;
    
    //Local Variables
    private float DecayTime;
    private float ThrowTime = 0;

    public ThrowingScript tp;

    public int NumberOfCheeseToSatisfy = 1;

    void CorrectCheese()
    {
        Happiness += 5;
        Angriness -= 5;
        Health += 20;
        NumberOfCheeseToSatisfy -= 1;
    }

    public void RecieveCheese(Cheese type)
    {
        bool SatisfiedOne = false;
        if (type.IntelliEffect != 0 && Intelligence != 0)
        {
            CorrectCheese();
            SatisfiedOne = true;
        }
        else if (type.StrengthEffect != 0 && Strength != 0)
        {
            CorrectCheese();
            SatisfiedOne = true;
        }
        else if (type.CharismaEffect != 0 && Charisma != 0)
        {
            CorrectCheese();
            SatisfiedOne = true;
        }
        else if (type.SpeedEffect != 0 && SpeedCheese != 0)
        {
            CorrectCheese();
            SatisfiedOne = true;
        }

        if(NumberOfCheeseToSatisfy<=0&& SatisfiedOne) //Go Home
        {
            SatDown = false;
            CurrentState = new LeaveState();

        }
        else
        { //ANGRY
            Happiness -= 5;
            Angriness += 5;
        }    



    }


    public void Start()
    {
        BaseSpeed = Speed;
        CurrentState = new Move();
        Rig = GetComponent<Rigidbody>();
        tp = GetComponent<ThrowingScript>();

        
    }


    public StateObject Target;


    public float TimeSinceThrowing()
    {
        return Time.time - ThrowTime;
    }

    public void SetThrowTime()
    {
        ThrowTime = Time.time;
    }

    public void Update()
    {
        Debug.Log(CurrentState);
        if (Active)
        {
            CurrentState.Execute(this);
        }


        if(Health<=0)
        {
            SitIn.Occupied = false;
            Destroy(gameObject);
        }

    }

    public void FixedUpdate()
    {
        SimulateFeelings();



        if (Target != null)
        {
            if (Target.GetComponent<Chair>())
            {
                if (Target.GetComponent<Chair>().Occupied)
                {
                    CurrentState = new Evaluate();

                }
                else
                {
                    if (Vector3.Distance(transform.position, Target.transform.position) <= 2.0f)
                    {
                        transform.position = Target.transform.position + Vector3.up * 0.3f;
                        Rig.velocity = new Vector3(0, 0, 0);
                        Rig.isKinematic = true;
                        Target.GetComponent<Chair>().Occupied = true;
                        SatDown = true;
                        SitIn = Target.GetComponent<Chair>();
                        Target = null;
                        CurrentState = new SittingState();
                    }
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


    private void SimulateFeelings()
    {
        //Natural Decay
        if(Time.time-DecayTime>=TimeBetweenDecay)
        {
            Happiness -= BasicDecayAmount;
            if (Happiness < 0)
            {
                Happiness = 0;
            }
            Angriness += BasicDecayAmount;
            Patience -= BasicDecayAmount * 1.5f;
            if (Patience < 0)
            {
                Patience = 0;
            }

            Hunger -= BasicDecayAmount;
            if(Hunger<=0)
            {
                Debug.Log("I AM DEAD");
            }


            DecayTime = Time.time;
        }



    }
   

    public void FindTarget()
    {
        Punter[] temp=FindObjectsOfType<Punter>();

        List<Punter> sorted = new List<Punter>();
        foreach(Punter el in temp)
        {
            if(el.Team!=Team)
            {
                sorted.Add(el);
            }
        }

        Victim = sorted[Random.Range(0, sorted.Count - 1)];

    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag=="Exit")
        {
            Destroy(gameObject);

        }

    }

}

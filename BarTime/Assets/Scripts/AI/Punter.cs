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

    public GameObject BlueJersey;
    public GameObject RedJersey;


    //Local Variables
    private float DecayTime;
    private float ThrowTime = 0;

    public ThrowingScript tp;

    public int NumberOfCheeseToSatisfy = 1;


    public ManagerMan temp;

    void CorrectCheese(Cheese Type)
    {
        Happiness += 5;
        Angriness -= 5;
        Health += 20;
        NumberOfCheeseToSatisfy -= 1;

        if(Type.StrengthEffect!=0)
        {
            Strength = 10;
        }
        else if (Type.SpeedEffect != 0)
        {
            SpeedCheese = 10;
        }
        else if (Type.IntelliEffect != 0)
        {
            Intelligence = 10;
        }
        else if (Type.CharismaEffect != 0)
        {
            Charisma = 10;
        }




       // Strength += Type.StrengthEffect;
       // Speed += Type.SpeedEffect;
       // Intelligence += Type.IntelliEffect;
        //Charisma += Type.CharismaEffect;
    }

    public void RecieveCheese(Cheese type)
    {
        bool SatisfiedOne = false;
        if (type.IntelliEffect != 0 && Intelligence != 10)
        {
            Debug.Log("wow, i loved eating that intelligence cheese!");
            CorrectCheese(type);
            SatisfiedOne = true;
        }
        else if (type.StrengthEffect != 0 && Strength != 10)
        {
            Debug.Log("wow, i loved eating that strength cheese!");
            CorrectCheese(type);
            SatisfiedOne = true;
        }
        else if (type.CharismaEffect != 0 && Charisma != 10)
        {
            Debug.Log("wow, i loved eating that charisma cheese!");
            CorrectCheese(type);
            SatisfiedOne = true;
        }
        else if (type.SpeedEffect != 0 && SpeedCheese != 10)
        {
            Debug.Log("wow, i loved eating that speed cheese!");
            CorrectCheese(type);
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

        if (Team)
        {
            BlueJersey.gameObject.SetActive(false);
        }
        else
        {
            RedJersey.gameObject.SetActive(false);
        }
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
        //Debug.Log(CurrentState);
        if (Active)
        {
            CurrentState.Execute(this);
        }


        if(Health<=0)
        {
            SitIn.Occupied = false;
            temp.TotalMoney -= 30;
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
                    if (Vector3.Distance(transform.position, Target.transform.position) <= 0.5f)
                    {
                        transform.position = Target.transform.position + Vector3.up * 0.3f;
                        Rig.velocity = new Vector3(0, 0, 0);
                        Rig.isKinematic = true;
                        Target.GetComponent<Chair>().Occupied = true;
                        SatDown = true;
                        SitIn = Target.GetComponent<Chair>();
                        SitIn.Owner.inhabitantList.Add(this);
                        if(SitIn.Owner.ShouldShowUI)
                        {
                            GetComponent<PopulateUI>().HideUI();
                        }
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
        if (sorted.Count != 0)
        {
            Victim = sorted[Random.Range(0, sorted.Count - 1)];
        }

    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag=="Exit")
        {
            Destroy(gameObject);

        }

    }

    public void SelfDestruct()
    {
        if(SitIn != null)
        SitIn.Owner.inhabitantList.Remove(this);
        Destroy(gameObject);
    }


}

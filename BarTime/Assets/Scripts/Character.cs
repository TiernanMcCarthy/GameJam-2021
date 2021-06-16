using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update

    CharacterController Player;

    public float Speed = 5.0f;

    public Punter CurrentTarget;

    public Cheese CurrentCheese;

    void Movement()
    {

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //IsMoving = true;

            Player.Move(new Vector3(-Input.GetAxisRaw("Horizontal"),0,-Input.GetAxisRaw("Vertical") ) * Speed * Time.deltaTime);
            Player.Move(Vector3.up * Time.deltaTime * Physics.gravity.y);

        }

    }





    void Start()
    {
        Player = GetComponent<CharacterController>();
    }
    public struct Punt
    {
        public int Index;
        public Punter Sample;
        public Punt(int ind, Punter s)
        {
            Sample = s;
            Index = ind;
        }

    }

    private void FixedUpdate()
    {
        ScanForPunters();
    }
    void ScanForPunters()
    {
        Collider[] hitList = Physics.OverlapSphere(transform.position, 0.5f);
        List<Punt> ClosestPositions = new List<Punt>();
        for (int i = 0; i < hitList.Length; i++)
        {
            if (hitList[i].gameObject != gameObject && hitList[i].gameObject.GetComponent<Punter>())
            {
                Punt Close = new Punt(i, hitList[i].gameObject.GetComponentInParent<Punter>());
                ClosestPositions.Add(Close);

            }
        }
        if (ClosestPositions.Count != 0)
        {

            if (ClosestPositions.Count > 1)
            {
                for (int i = 0; i < ClosestPositions.Count - 1; i++) //Iterate through these and find the closest position by sorting
                {


                    if (Vector3.Distance(ClosestPositions[i].Sample.transform.position, transform.position) > Vector3.Distance(ClosestPositions[i + 1].Sample.transform.position, transform.position))
                    {
                        Punt temp = ClosestPositions[i];
                        ClosestPositions[i] = ClosestPositions[i + 1]; //Swap these positions
                        ClosestPositions[i + 1] = temp;
                        i = -1; //Reiterate
                    }

                }
            }
            // SetVehicle(hitList[ClosestPositions[0].Index].gameObject); //set the target vehicle
            //Target = ClosestPositions[0].Sample;
            CurrentTarget = ClosestPositions[0].Sample;
        }
        else
        {
            CurrentTarget = null;
        }

    }

    public void GiveCheese()
    {
        if (CurrentTarget != null)
        {
            CurrentTarget.RecieveCheese(CurrentCheese);
            Destroy(CurrentCheese.gameObject);
            CurrentCheese = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Movement();

        if(Input.GetKeyDown("e"))
        {
            GiveCheese();
        }

        if(CurrentCheese!=null)
        {
            CurrentCheese.transform.position = transform.position + transform.up * 1;
        }

    }
}
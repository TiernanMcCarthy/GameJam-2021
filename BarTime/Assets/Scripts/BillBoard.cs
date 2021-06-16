using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{

    private Camera cameraObject;

    public bool UseStaticBillBoard;
    // Start is called before the first frame update
    void Start()
    {
        cameraObject = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (!UseStaticBillBoard)
        {
            transform.LookAt(cameraObject.transform);
        }
        else
        {
            transform.rotation = cameraObject.transform.rotation;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }
}

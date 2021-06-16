using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUI : MonoBehaviour
{
    Camera Cam;

    // Start is called before the first frame update
    void Start()
    {
        Cam=GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<PopulateUI>())
                {
                    PopulateUI temp = hit.collider.gameObject.GetComponent<PopulateUI>();
                    temp.HideUI();
                }
            }
        }
    }
}

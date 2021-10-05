using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUI : MonoBehaviour
{
    Camera Cam;
    Table PreviousTable;
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
                if (hit.collider.gameObject.GetComponent<Table>())
                {
                    //Debug.Log("Hit the table king");
                    Table thisTable = hit.collider.gameObject.GetComponent<Table>();
                    ToggleTableUi(thisTable);
                    if(PreviousTable != null && PreviousTable != thisTable)
                    {
                        ToggleTableUi(PreviousTable);
                    }
                    PreviousTable = thisTable;
                }
                else
                {
                    Debug.Log("yo man we missed :(... sorry for letting you down :/");
                }
            }
        }
    }

    void ToggleTableUi(Table ToToggle)
    {
        ToToggle.ShouldShowUI = !ToToggle.ShouldShowUI;
        Debug.Log("The value for ShouldShowUI is " + ToToggle.ShouldShowUI);
        foreach (Punter p in ToToggle.inhabitantList)
        {
            if(p!=null)
            p.gameObject.GetComponent<PopulateUI>().HideUI();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCam;

    public Map Map;

    public Transform LeftHand;
    private bool draw;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        Map = FindObjectOfType<Map>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Map")
                {
                    Debug.Log(hit.transform.tag);
                    Debug.Log(hit.transform.InverseTransformPoint(hit.point));
                    Map.Paint(hit.transform.InverseTransformPoint(hit.point).x, hit.transform.InverseTransformPoint(hit.point).z,1);
                }
            }
            
        }

        if (draw)
        {
            RaycastHit hit;
            if (Physics.Raycast(LeftHand.position, LeftHand.forward, out hit, 100))
            {
                if (hit.transform.tag == "Map")
                {
                    Debug.Log(hit.transform.tag);
                    Debug.Log(hit.transform.InverseTransformPoint(hit.point));
                    var point = hit.transform.InverseTransformPoint(hit.point);

                    Map.Paint(point.x,point.z,1);
                }
            }
        }
    }

    public void TriggerStart()
    {
        draw = true;
    }

    public void TriggerEnd()
    {
        draw = false;
    }
}

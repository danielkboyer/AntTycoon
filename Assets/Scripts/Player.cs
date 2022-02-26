using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera camera;

    public Map Map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            var ray = camera.ScreenPointToRay(Input.mousePosition);
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
    }
}

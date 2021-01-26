using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshBehaviour : MonoBehaviour
{
    public GameObject endpoint;
    public GameObject mesh;
    public bool startRendering;
    // Start is called before the first frame updates
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {
        if (startRendering)
        {
            float distance;
            Vector3 positionA = gameObject.transform.position;
            Vector3 positionB = endpoint.transform.position;


            distance = Vector3.Distance(positionA, positionB);
            mesh.transform.localScale = new Vector3(0.2f, distance, 0.2f);
            mesh.transform.position = positionA;
            mesh.transform.LookAt(positionB);
            mesh.transform.Rotate(90, 0, 0);
            //print(distance);
        }
    }
}

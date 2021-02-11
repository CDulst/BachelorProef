using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableMovement : MonoBehaviour
{
    float timeCounter = 0;
    public float speed;
    public GameObject tablepos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += speed + Time.deltaTime;
        float x = tablepos.transform.position.x + Mathf.Cos(timeCounter);
        float y = 0;
        float z = tablepos.transform.position.z + Mathf.Sin(timeCounter); ;
        transform.position = new Vector3(x, transform.position.y, z);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementChecker : MonoBehaviour
{
    public Rigidbody rigid;
    public bool running = false;
    public bool notRunning = true;
    public Machine2Animation projector;
    public List<Vector3> positionsList = new List<Vector3>();
    public float velocity;
    public VelocityCalc scriptVelocity;
    public int i = 300;

    public
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        GameObject Velocity = GameObject.Find("VelocityManager");
        scriptVelocity = Velocity.GetComponent<VelocityCalc>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = scriptVelocity.CalculateVelocity(gameObject.transform.position, positionsList).magnitude;
        print(velocity);

        StartCoroutine(WaitTimeRunning());
        
        if (!running)
        {
            if (velocity > i)
            {
                Debug.Log("running");
                projector.StartUp();
                //running = true;
                //StartCoroutine(WaitTimeRunning());
            }
        }
        else if (!notRunning)
        {
            if (velocity < 0)
            {
                Debug.Log("notRunning");
                projector.Stopping();
                //notRunning = true;
                //StartCoroutine(WaitTimeNotRunning());
            }
        }
    }

    public IEnumerator WaitTimeRunning()
    {
        yield return new WaitForSeconds(1);
        i = 6;
    }
    public IEnumerator WaitTimeNotRunning()
    {
        yield return new WaitForSeconds(4);
        running = false;
    }
}

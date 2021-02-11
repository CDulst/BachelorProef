using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueTest : MonoBehaviour
{
    private Rigidbody rb;
    private Rigidbody tunnelRb;
    public float speed = 3f;
    public GameObject tunnel;
    public float movementKinectFactor;

    public BodySourceView scriptBodySourceView;
    public VelocityCalc scriptVelocity;
    public arrowMovement arrowScript;
    public Vector3 velocity;
    public List<Vector3> positionsList = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        tunnelRb = tunnel.GetComponent<Rigidbody>();

        GameObject KinectAvatar = GameObject.Find("KinectAvatar");
        scriptBodySourceView = KinectAvatar.GetComponent<BodySourceView>();

        GameObject Velocity = GameObject.Find("VelocityManager");
        scriptVelocity = Velocity.GetComponent<VelocityCalc>();

        GameObject arrow = GameObject.Find("arrow");
        arrowScript = arrow.GetComponent<arrowMovement>();


    }

    // Update is called once per frame
    void Update()
    {
        
        velocity = scriptVelocity.CalculateVelocity(scriptBodySourceView.manoDer, positionsList);
        if (velocity.z > 8 || velocity.z < -8)
        {
            
            rb.AddTorque(-transform.forward * speed * 90);
            tunnelRb.AddRelativeTorque(0, 40, 0);

        }

        else if(velocity.z > 8 || velocity.z < -8)
        {
            tunnelRb.AddRelativeTorque(0, 100, 0);
        }
        print(arrowScript.buildingUpFactor);

        if(arrowScript.buildingUpFactor < 0.6)
        {
            arrowScript.buildingUpFactor = (velocity.z/20);
        }else
        {
            arrowScript.buildingUpFactor = 1;
        }

        
        
    }
}

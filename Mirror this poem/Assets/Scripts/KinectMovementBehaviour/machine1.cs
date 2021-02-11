using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine1 : MonoBehaviour
{

    public BodySourceView scriptBodySourceView;
    public VelocityCalc scriptVelocity;
    public Vector3 velocityHandRight;
    public Vector3 velocityHandLeft;
    public List<Vector3> positionsListRight = new List<Vector3>();
    public List<Vector3> positionsListLeft = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        



        GameObject Velocity = GameObject.Find("VelocityManager");
        
        scriptVelocity = Velocity.GetComponent<VelocityCalc>();

        GameObject KinectAvatar = GameObject.Find("KinectAvatar");
        scriptBodySourceView = KinectAvatar.GetComponent<BodySourceView>();




    }

    // Update is called once per frame
    void Update()
    {      
            velocityHandRight = scriptVelocity.CalculateVelocity(scriptBodySourceView.manoDer, positionsListRight);
            velocityHandLeft = scriptVelocity.CalculateVelocity(scriptBodySourceView.manoIzk, positionsListLeft);
            
            
            if (velocityHandRight.x > 10)
            {
                GetComponent<Rigidbody>().AddRelativeForce(0, 0, 100f);
            }
            if (velocityHandRight.x < -10)
            {
                GetComponent<Rigidbody>().AddRelativeForce(0, 0, -100f);
            }
            
            if (velocityHandLeft.x > 10)
            {
                GetComponent<Rigidbody>().AddRelativeForce(0, 0, 100f);
            }
            if (velocityHandLeft.x < -10)
            {
                GetComponent<Rigidbody>().AddRelativeForce(0, 0, -100f);
            }
        
        

    }
}

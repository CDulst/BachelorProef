using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine4 : MonoBehaviour
{
    public BodySourceView scriptBodySourceView;
    public VelocityCalc scriptVelocity;
    public Vector3 velocityRightHand;
    public Vector3 velocityLeftHand;
    public List<Vector3> positionsListRight = new List<Vector3>();
    public List<Vector3> positionsListLeft = new List<Vector3>();
    public bool canStartLeft = false;
    public bool canStartRight = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject KinectAvatar = GameObject.Find("KinectAvatar");
        scriptBodySourceView = KinectAvatar.GetComponent<BodySourceView>();

        GameObject Velocity = GameObject.Find("VelocityManager");
        scriptVelocity = Velocity.GetComponent<VelocityCalc>();
    }

    // Update is called once per frame
    void Update()
    {
        velocityRightHand = scriptVelocity.CalculateVelocity(scriptBodySourceView.manoDer, positionsListRight);
        velocityLeftHand = scriptVelocity.CalculateVelocity(scriptBodySourceView.manoIzk, positionsListLeft);
        if (velocityRightHand.y > 20)
        {
            canStartRight = true;
        }
        if (velocityLeftHand.y > 20)
        {
            canStartLeft = true;
        }
    }
}

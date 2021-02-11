using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine7 : MonoBehaviour
{
    // Start is called before the first frame update
    public BodySourceView scriptBodySourceView;
    public VelocityCalc scriptVelocity;
    public Vector3 velocity;
    public List<Vector3> positionsList = new List<Vector3>();
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
        velocity = scriptVelocity.CalculateVelocity(scriptBodySourceView.manoDer, positionsList);
        if (velocity.x > 10)
        {
            canStartRight = true;
            canStartLeft = false;
        }
        if (velocity.x < -10)
        {
            canStartLeft = true;
            canStartRight = false;
        }
    }
}

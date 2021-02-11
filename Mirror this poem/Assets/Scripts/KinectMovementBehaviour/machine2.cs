using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine2 : MonoBehaviour
{
    public BodySourceView scriptBodySourceView;
    public VelocityCalc scriptVelocity;
    public TableMovement tableMovScript;
    public Vector3 velocityHandRight;
    public Vector3 velocityHandLeft;

    public List<Vector3> positionsListRight = new List<Vector3>();
    public List<Vector3> positionsListLeft = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject KinectAvatar = GameObject.Find("KinectAvatar");
        scriptBodySourceView = KinectAvatar.GetComponent<BodySourceView>();
        
        GameObject Velocity = GameObject.Find("VelocityManager");
        scriptVelocity = Velocity.GetComponent<VelocityCalc>();

        GameObject Table = GameObject.Find("Table");
        tableMovScript = Table.GetComponent<TableMovement>();


    }

    // Update is called once per frame
    void Update()
    {
        velocityHandRight = scriptVelocity.CalculateVelocity(scriptBodySourceView.manoDer, positionsListRight);
        velocityHandLeft = scriptVelocity.CalculateVelocity(scriptBodySourceView.manoIzk, positionsListLeft);


        if (velocityHandRight.x > 10 || velocityHandRight.x < -10)
        {
            tableMovScript.speed += 0.001f;

            if(tableMovScript.speed > 0.080f)
            {
                tableMovScript.speed = 0.080f;
            }
        }

        if (velocityHandLeft.x > 10 || velocityHandLeft.x < -10)
        {
            tableMovScript.speed += 0.001f;

            if (tableMovScript.speed > 0.080f)
            {
                tableMovScript.speed = 0.080f;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine6 : MonoBehaviour
{
    public BodySourceView scriptBodySourceView;
    public VelocityCalc scriptVelocity;
    public BallSpwner scriptBallSpawnerRight;
    public BallSpwner scriptBallSpawnerLeft;
    public BallSpwner scriptBallSpawnerBottom;
    public Vector3 velocity;
    public List<Vector3> positionsList = new List<Vector3>();
    private bool runOnce = false;
    public PopUp popUp;

    void Start()
    {
        popUp.CreatePopUp();

        GameObject KinectAvatar = GameObject.Find("KinectAvatar");
        scriptBodySourceView = KinectAvatar.GetComponent<BodySourceView>();

        GameObject Velocity = GameObject.Find("VelocityManager");
        scriptVelocity = Velocity.GetComponent<VelocityCalc>();

        GameObject spawnerRight = GameObject.Find("BallspwnerRight");
        scriptBallSpawnerRight = spawnerRight.GetComponent<BallSpwner>();

        GameObject spawnerLeft = GameObject.Find("BallspwnerLeft");
        scriptBallSpawnerLeft = spawnerLeft.GetComponent<BallSpwner>();

        GameObject spawnerBottom = GameObject.Find("BallspwnerBottom");
        scriptBallSpawnerBottom = spawnerBottom.GetComponent<BallSpwner>();



    }

    // Update is called once per frame
    void Update()
    {
        velocity = scriptVelocity.CalculateVelocity(scriptBodySourceView.manoDer, positionsList);

        if(velocity.x > 10 && !runOnce)
        {
            scriptBallSpawnerRight.shootBall();
            
            runOnce = true;
        }else if (velocity.x < -10 && !runOnce)
        {
            scriptBallSpawnerLeft.shootBall();
          
            runOnce = true;
        }else if (velocity.y > 10)
        {
            scriptBallSpawnerBottom.shootBall();
           
        } 
        else
        {
            runOnce = false;
        }
    }
}

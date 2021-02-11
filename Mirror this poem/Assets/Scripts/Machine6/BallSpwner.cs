using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpwner : MonoBehaviour
{
    public GameObject ball;
    [Range(0,1)] public float force;
    public PopUp popUp;

    private void Update()
    {
        //shootBall();
    }


    public void shootBall ()
    {
        popUp.deletePopUp();
        GameObject sphere =  Instantiate(ball, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        sphere.transform.parent = transform;
      
        sphere.GetComponent<Rigidbody>().AddRelativeForce(force * 800, 0, 0);        
    }


}

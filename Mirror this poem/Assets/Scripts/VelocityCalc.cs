using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityCalc : MonoBehaviour
{
    public Vector3 currentPosition;
    public Vector3 previousPosition;
    public GameObject leftHand;
    public GameObject rightHand;
    public BodySourceView scriptBodySourceView;



    public Vector3 CalculateVelocity(Vector3 limbPosition, List<Vector3> listPosition)
    {

        listPosition.Add(limbPosition);
        listPosition.Reverse();

        if (listPosition.Count > 2)
        {
            currentPosition = listPosition[0];
            previousPosition = listPosition[1];
        }

        return (currentPosition - previousPosition) / Time.deltaTime;

    }
}

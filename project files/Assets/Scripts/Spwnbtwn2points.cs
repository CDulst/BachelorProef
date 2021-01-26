using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwnbtwn2points : MonoBehaviour
{

    public int inbetweenPoints;
    public float distance;
    public Vector3 step;
    public GameObject prefabCube;
    Vector3[] positionArray;
    Vector3[] positionArrayBezier;
    public List<GameObject> spawnedCubes;
    public Vector3 j;
    public Vector3 v;

    private Vector3 position1Vector3;
    private Vector3 position2Vector3;
    private Vector3 position3Vector3;
    // Start is called before the first frame update
    void Start()
    {
    }

    public List<GameObject> spawningPoints(GameObject p1, GameObject p2, GameObject p3 )
    {
        positionArray = new Vector3[inbetweenPoints];
        positionArrayBezier = new Vector3[inbetweenPoints];
        position1Vector3 = p1.transform.position;
        position2Vector3 = p2.transform.position;
        if (p3 != null)
        {
            position3Vector3 = p3.transform.position;

        }
        distance = Vector3.Distance(position1Vector3, position2Vector3);


        j = LerpByDistance(position1Vector3, position2Vector3, 2.0f);


        for (int i = 1; i <= inbetweenPoints - 1; i++)
        {
            if (p3 == null)
            {
                j = LerpByDistance(position1Vector3, position2Vector3, distance / inbetweenPoints * i);
                positionArray[i] = j;
                GameObject cube = Instantiate(prefabCube, positionArray[i], Quaternion.identity);
                spawnedCubes.Add(cube.gameObject);
            }
            else
            {
                float t = i / (float)inbetweenPoints;
                v = CalculateQuadraticBezierPoint(t, position1Vector3, position3Vector3, position2Vector3);
                positionArrayBezier[i] = v;
                GameObject cube = Instantiate(prefabCube, positionArrayBezier[i], Quaternion.identity);
                spawnedCubes.Add(cube.gameObject);
            }
    
        }
        return spawnedCubes;
    }


    public Vector3 LerpByDistance(Vector3 A, Vector3 B, float x)
    {
        Vector3 P = x * Vector3.Normalize(B - A) + A;
        return P;
    }
    public Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {

        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }

}

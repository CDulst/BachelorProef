using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawn : MonoBehaviour
{

    public List<GameObject> positions;
    public GameObject endpoint;
    public GameObject midpoint = null;
    public Spwnbtwn2points psw;
    public GameObject mesh;
    public int current = 0;




    // Start is called before the first frame update
    void Start()
    {

        positions = GetComponent<Spwnbtwn2points>().spawningPoints(gameObject, endpoint, midpoint);

        addStartAndEnd(positions);
        GameObject previous;
        GameObject next;
        foreach (GameObject position in positions)
        {
            if (current != 0)
            {
                previous = positions[current - 1];
            }
            else
            {
                previous = null;
            }
            if (current < positions.Count-1)
            {
                next = positions[current + 1];
            }
            else
            {
                next = null;
            }
            AddJoints(position, previous, next);
            AddRenderer(position, next);
            AddMesh(position, next);
            current += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void addStartAndEnd(List<GameObject> positions)
    {
        positions.Insert(0, gameObject);
        positions.Add(endpoint);
    }

    void AddJoints(GameObject position, GameObject previous, GameObject next)
    {
        if (previous != null)
        {
            position.GetComponents<SpringJoint>()[0].connectedBody = previous.GetComponent<Rigidbody>();
        }
        if (next != null)
        {
            position.GetComponents<SpringJoint>()[1].connectedBody = next.GetComponent<Rigidbody>();
        }
    }

    void AddRenderer(GameObject position, GameObject next)
    {
        if (next != null)
        {
            position.GetComponent<RopeRendered>().Endpoint = next;
        }
    }
    void AddMesh(GameObject position, GameObject next)
    {
        if (next != null)
        {
            GameObject spawned = Instantiate(mesh);
            position.GetComponent<MeshBehaviour>().endpoint = next;
            position.GetComponent<MeshBehaviour>().mesh = spawned;
            position.GetComponent<MeshBehaviour>().startRendering= true;
        }
    }




}

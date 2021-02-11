using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    public List<Material> lightMaterials;
    public List<Color> lightColors;
    public Light lightComp;
    public MeshRenderer meshComp;
    public int current = 0;

    public void Start()
    {
        lightComp = gameObject.GetComponent<Light>();
        meshComp = gameObject.GetComponent<MeshRenderer>();
    }


    public void NextLight()
    {
        lightComp.color = lightColors[current];
        meshComp.material = lightMaterials[current];
        if (current < lightColors.Count-1)
        {
            current += 1;
        }
        else
        {
            current = 0;
        }
    }
}

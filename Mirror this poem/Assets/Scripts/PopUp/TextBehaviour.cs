using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBehaviour : MonoBehaviour
{
    public GameObject TextGameObject;
    private Animator animator;
    private TextMesh textMesh;
    List<string> textValues = new List<string>();
    public float length;
    public int i = 1;
    public int y = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        textMesh = gameObject.GetComponent<TextMesh>();
        textValues.Add("Swipe");
        textValues.Add("Your");
        textValues.Add("Hands!");
        animator.Play("Text animation");
        

    }

    // Update is called once per frame
    void Update()
    {
        bool state = AnimatorIsPlaying();
        
        if (!state)
        {

            gameObject.transform.localPosition = new Vector3(Random.Range(0,0.6f), Random.Range(0,0.6f), 2);

            if (textValues != null)
            {
                
                textMesh.text = textValues[y++];
            
                

                if(y > 2)
                {
                    y = 0;
                }
                i++;

            }
        }
    }

    bool AnimatorIsPlaying()
    {
        length = animator.GetCurrentAnimatorStateInfo(0).length*i;
        if(length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            return true;
        }else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < length)
        {
            return false;
        }
        else
        {
            return false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLoader : MonoBehaviour
{
   public Animator transition;
   
   public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
    }
    
    public void LoadNextScene()
    {
       StartCoroutine(LoadScene(1));
       // SceneManager.GetActiveScene().buildIndex + 1 
       // dit is voor meerdere scenes
       
    }
    
    IEnumerator LoadScene(int sceneIndex)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(sceneIndex);
        
        
    }
}

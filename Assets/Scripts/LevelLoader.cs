using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void LoadNextLevel()
    {
        Debug.Log("Loading next level scene is: " + SceneManager.GetActiveScene().buildIndex);

        if (Retry_scene.retry_number > 0)
        {
            Debug.Log("Loading current level again" + Retry_scene.retry_number);
            Retry_scene.retry_number--;
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        }
        else
        {
            Debug.Log("Got into the else");
            Retry_scene.retry_number += 3;
            //  Last stage will loop
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
            }
            else
            {
                Debug.Log("Ended retrys");
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
    }

    public void LoadEndScreen()
    {
        
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Debug.Log("Loading end scene is: " + SceneManager.GetActiveScene().buildIndex);

            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.Log("Loading else scene is: " + SceneManager.GetActiveScene().buildIndex);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    } 
}

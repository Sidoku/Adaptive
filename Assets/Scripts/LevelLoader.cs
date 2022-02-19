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


        //  Last stage will loop
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        }
        else
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
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

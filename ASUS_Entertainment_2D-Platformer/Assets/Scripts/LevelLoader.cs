using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    public GameObject player;
    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        //Play anim
        transition.SetTrigger("End");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        // Wait until the scene is fully loaded
        while (!operation.isDone)
        {
            player.transform.position = new Vector2(-7, 1);
            yield return null;
        }
        transition.SetTrigger("Start");
    }
}

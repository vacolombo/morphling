using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roundButton : MonoBehaviour
{

    public void LoadScene()
    {
        //Debug.Log(SceneManager.GetActiveScene().buildIndex.ToString());
        roundManager.Instance.ChangeRound(1);
        StartCoroutine(loadSceneAsync());
        
    }

    IEnumerator loadSceneAsync()
    {
        
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}

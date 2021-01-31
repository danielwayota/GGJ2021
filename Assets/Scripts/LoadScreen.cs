using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    public static string nextLevel;

    public static void LoadLevel(string name)
    {
        nextLevel = name;
        SceneManager.LoadScene("Loading");
    }

    void Awake()
    {
        StartCoroutine(this.LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(.8f);

        var progress = SceneManager.LoadSceneAsync(nextLevel);

        while (!progress.isDone)
        {
            yield return null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCtrl : MonoBehaviour
{
    public float Waitsec;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneTimer());
    }

    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator SceneTimer()
    {
        yield return new WaitForSecondsRealtime(Waitsec);
        LoadScene();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCtrl : MonoBehaviour
{
    public float Waitsec;
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneTimer());
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            OpenBook();
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator SceneTimer()
    {
        yield return new WaitForSecondsRealtime(Waitsec);
        StopBook();
    }

    void StopBook()
    {

    }

    void OpenBook()
    {
        LoadScene();
    }
}

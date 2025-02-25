using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    GameObject GM;
    GameObject Player;

    private void Start()
    {
        if (!GM)
        {
            Debug.Log("NullGM");
            GM = GameObject.Find("GM");
        }
        if (!Player)
        {
            Player = GameObject.Find("Player");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GameObject.Find("Player").GetComponent<Transform>().position = Vector2.zero;
            Camera.main.transform.position = Vector3.zero;
            GM.GetComponent<StageManager>().Upstage();
        }
    }
}

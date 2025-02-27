using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [SerializeField]
    GameObject GM;
    [SerializeField]
    GameObject Player;

    private void Start()
    {
        if (!GM)
        {
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
           Player.GetComponent<Transform>().position = new Vector2(0, -8);
            Camera.main.transform.position = Vector3.zero;
            GM.GetComponent<StageManager>().Upstage();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Timeline;
using UnityEngine;

public class ExpsCtrl : MonoBehaviour
{
    GameObject Player;
    public float Speed;

    public AudioClip ExpSound;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        AudioSource.PlayClipAtPoint(ExpSound, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Player.transform.position, Speed * Time.deltaTime);
        Speed += Time.deltaTime;
    }
    private void LateUpdate()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) <= 0.1)
        {
            Destroy(gameObject);
        }
    }
}

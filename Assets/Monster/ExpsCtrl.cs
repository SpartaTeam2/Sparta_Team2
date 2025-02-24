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
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Player.transform.position, Speed * Time.deltaTime);
        Speed+= Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed);
    }
    private void LateUpdate()
    {
        if (Vector2.Distance(transform.position,Player.transform.position)<=0.1)
        {
            Destroy(gameObject);
        }
    }
}

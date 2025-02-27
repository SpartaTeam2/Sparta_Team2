using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpsCtrl : MonoBehaviour
{
    PlayerCtrl player;
    public float Speed;

    public AudioClip ExpSound;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCtrl>();

        player.GetExps();

        AudioManager.Instance.PlaySfx(ExpSound);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, Speed * Time.deltaTime);
        Speed += Time.deltaTime;
    }
    private void LateUpdate()
    {
        // 예외처리
        if (player == null)
        {
            Destroy(gameObject);
            return;
        }

        if (Vector2.Distance(transform.position, player.transform.position) <= 0.1)
        {
            player.HP++;
            Destroy(gameObject);
        }
    }
}

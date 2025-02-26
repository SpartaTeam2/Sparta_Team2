using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private const string playerTag = "Player";
    private const string WallTag = "Wall";

    [SerializeField]
    private Rigidbody2D rigidbody;
    public float damage { get; set; }

    private void Start()
    {
        Destroy(gameObject, 10.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            collision.GetComponent<PlayerCtrl>().GetDamage(damage);
            Destroy(gameObject);
        }

        else if (collision.CompareTag(WallTag))
        {
            Destroy(gameObject);
        }

        else
        {
            Debug.Log($"어디에 박은거죠? >> {collision.name}");
            Destroy(gameObject);
        }
    }


    public void Shot(Vector2 velocity, bool isRandom = false)
    {
        float bulletSpeed = 5;
        if (isRandom)
            bulletSpeed = Random.Range(2f, 7f);
        rigidbody.velocity = velocity * bulletSpeed;
    }
}

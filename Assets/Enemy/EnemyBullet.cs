using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;
    public float damage { get; set; }

    private void Start()
    {
        Destroy(gameObject, 10.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                collision.GetComponent<PlayerCtrl>().GetDamage(damage);
                break;

            case "Wall":
                Destroy(gameObject);
                break;
            default:
                Debug.Log("ÀÌ°É ¾îÄ³ ¶ç¿üÀ½");
                break;
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

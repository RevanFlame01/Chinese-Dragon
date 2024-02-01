using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBullet : MonoBehaviour
{
    public static int killCounter = 0;
    [SerializeField] private float speed;
    [SerializeField] private GameObject explosionPartical;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Destroy(gameObject, 4f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Score.score += 10;
            Score.allScore += 10;
            
        }
        if (collision.gameObject.CompareTag("bird"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            PlayerController.hp--;
        }
        Instantiate(explosionPartical, transform.position, Quaternion.identity);
    }
}

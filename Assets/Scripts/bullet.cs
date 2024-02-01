using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private GameObject explosionPartical;
    
    [SerializeField] private float speed;

    




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
            SuperBullet.killCounter++;
            superButton.fillAmount += 0.25f;
            
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomBorder : MonoBehaviour
{

    [SerializeField] private GameObject particalenemy;
    [SerializeField] private GameObject particalBird;
    [SerializeField] private Vector3[] position;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            PlayerController.hp--;
            Instantiate(particalenemy, position[Random.Range(0, position.Length)], Quaternion.identity);

        }
        if (collision.gameObject.CompareTag("bird"))
        {
            Destroy(collision.gameObject);
            Score.score+=10;
            Score.allScore+=10;
            Instantiate(particalBird, position[Random.Range(0, position.Length)], Quaternion.identity);
        }
    }
}

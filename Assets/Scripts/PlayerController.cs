using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    [SerializeField] private float speed;
    [SerializeField] private float maxRotationZ = 40f;
    [SerializeField] private float minRotationZ = -40f;
    private float timeShots = 2;
    public static int hp = 3;

    private bool isShot = true;

    [SerializeField] private GameObject bulletGO;
    [SerializeField] private GameObject superBullet;
    [SerializeField] private GameObject superBulletButton;

    [SerializeField] private Transform shotsPoint;

    [SerializeField] private AudioSource shotsAudio;

    [SerializeField] private Text hpText;

    [Space(30)] [Header("Tutorial")] 
    [SerializeField] public GameObject TutorialPanel;
    [SerializeField][HideInInspector] private int TutorialStatus;

    [Space(20)] [Header("Game Over")] 
    [SerializeField] public GameObject GameOver_Panel;

    private void Start()
    {
        hp = 3;
        TutorialStatus = PlayerPrefs.GetInt("Tutorial");
    }
    private void FixedUpdate()
    {
        if (isMovingLeft)
        {
            transform.Rotate(0, 0, transform.rotation.z + speed);
        }
        if (isMovingRight)
        {
            transform.Rotate(0, 0, transform.rotation.z - speed*2);
        }

        
    }

    void Update()
    {
        TutorialStatus = PlayerPrefs.GetInt("Tutorial");

        if (TutorialStatus == 1)
        {
            TutorialPanel.SetActive(false);
            //Time.timeScale = 1f;
        }

        if (TutorialStatus == 0)
        {
            TutorialPanel.SetActive(true);
            //Time.timeScale = 0f;
        }

        if (hp <= 0)
        {
            GameOver_Panel.SetActive(true);
           // Time.timeScale = 0f;
        }

        if (GameOver_Panel.activeSelf == true)
        {
            Time.timeScale = 0f;
        }
        hpText.text = "HP: " + hp;
        
        PlayerPrefs.SetInt("score", Score.score);
        float currentZRotation = transform.eulerAngles.z;

        if (currentZRotation > 180)
        {
            currentZRotation -= 360; 
        }

        currentZRotation = Mathf.Clamp(currentZRotation, minRotationZ, maxRotationZ);

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            currentZRotation
            );


        
        if (timeShots <= 0)
        {
            isShot = true;
        }
        else
        {
            isShot = false;
            timeShots -= Time.deltaTime;
        }


        if (SuperBullet.killCounter >= 4)
        {
            superBulletButton.SetActive(true);
        }
        if(SuperBullet.killCounter <= 3)
        {
            superBulletButton.SetActive(false);
        }
    }

    public void _RotationLeft()
    {
        isMovingLeft = true;
    }
    public void _RotationRight()
    {
        isMovingRight = true;
    }

    public void Stop()
    {
        isMovingLeft = false;
        isMovingRight = false;
    }

    public void Shots()
    {
        if (isShot)
        {
            Instantiate(bulletGO, shotsPoint.position, shotsPoint.rotation);
            timeShots = 1f;
            shotsAudio.Play();
        }
    }

    public void superShot()
    {
        Instantiate(superBullet, new Vector3(1, -2.7f, 0), Quaternion.identity);
        shotsAudio.Play();
        SuperBullet.killCounter = 0;
        superButton.fillAmount = 0;

    }
}

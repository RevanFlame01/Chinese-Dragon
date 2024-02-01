using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaner : MonoBehaviour
{
    [SerializeField]private float time = 20;
    private void Update()
    {

        time -= 1f*Time.deltaTime;
        if (time <= 0)
        {
            GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("partical");

            foreach (GameObject obj in objectsToDelete)
            {
                Destroy(obj);
            }
            time = 20;
        }
        
    }
}

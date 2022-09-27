using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameeraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
        {
            if (0.00000001f < transform.eulerAngles.z / 2.0f)
            {
                Debug.Log("Обнуляем типа мало");
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
            else
            {
                Debug.Log("Сглаживаем");
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z / 2.0f);
            }
        }
        else
        {
            Debug.Log("Обнуляем по клавишам");
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
    }
}

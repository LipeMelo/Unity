using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    void Awake()
    {
      
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        
        if(Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 180);

        }
        
        if(Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 90);

        }

        if(Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, -90);

        }
    }
}

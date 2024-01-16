using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Estados // Maquina de estado
{
    Waiting,
    Left,
    Right

}

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Estados states = Estados.Waiting; 

    void Start()
    {
    
    }
    
    
    void Update()
    {
        switch(states)
        {
            case Estados.Waiting: 
                break;

            case Estados.Left:
                this.gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                this.gameObject.transform.localRotation = Quaternion.Euler (0, 180, 0);
                break;

            case Estados.Right:
                this.gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                this.gameObject.transform.localRotation = Quaternion.Euler (0, 0, 0);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ECollision")
        {
            if (states == Estados.Right)
            {
                states = Estados.Left;
            }
            else
            {
                states = Estados.Right;
            }
        }
        else if (collision.gameObject.tag == "MainCamera")
        {
            states = Estados.Left;
        }
    }
    private void OnTriggerExit2D(Collider2D  collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            states = Estados.Waiting;
        }
    }
}
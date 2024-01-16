using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private bool isOnFloor;
    [SerializeField] private Transform bulletRef;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float delayBullet = 0;
    [SerializeField] private float fireRate = 1;
    [SerializeField] private bool first;

    void Awake()
    {
      
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0); //movimento Direito
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0); // Rotação para Direita
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
    
        if(Input.GetKey(KeyCode.W) && isOnFloor)
        {
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isOnFloor = false;
        }
        
        if(Input.GetKey(KeyCode.G))
        {
            BulletFunction();
        }
    }

    private void update ()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            first = false;
        }
    }

    private void BulletFunction()
    {
        if(first == false)
        {
            Instantiate(bulletPrefab, bulletRef.position, bulletRef.rotation);
            first = true;
        }

        delayBullet += fireRate * Time.deltaTime;
        if (delayBullet >= 1f)
       {
         delayBullet = 0;
         Instantiate(bulletPrefab, bulletRef.position, bulletRef.rotation);
       }        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isOnFloor = true;
        }
    }
}


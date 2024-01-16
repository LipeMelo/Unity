using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float delayToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        delayToDestroy += 1f * Time.deltaTime;
        if (delayToDestroy > 2f)
        {
            Destroy(this.gameObject);
        }
    }
}

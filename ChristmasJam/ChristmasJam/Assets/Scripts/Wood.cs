using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] AudioSource woodSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 7)
        {
            Destroy(gameObject);
        }
        if (collision.relativeVelocity.magnitude > 3)
        {
            if (collision.gameObject.CompareTag("Wood"))
            {
                woodSound.Play();
            }
        }
        if ((collision.relativeVelocity.magnitude > 3) && collision.gameObject.CompareTag("Anvil"))
        {
            Destroy(gameObject);
        }
    }
}

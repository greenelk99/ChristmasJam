using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField] AudioSource presentDestroyed;
    [SerializeField] float maxVelocity;
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
        if(collision.relativeVelocity.magnitude > maxVelocity)
        {
            presentDestroyed.Play();
            Invoke("Die", 0.04f);
        }
        else if (collision.relativeVelocity.magnitude > 1 && collision.gameObject.CompareTag("Anvil"))
        {
            presentDestroyed.Play();
            Invoke("Die", 0.04f);
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}

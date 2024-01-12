using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Present : MonoBehaviour
{

    [SerializeField] AudioSource presentDestroyed;
    [SerializeField] float maxVelocity;

    private SFXScript SFX;
    private static bool isResetted;

    void Start()
    {
        SFX = GameObject.Find("SFX").GetComponent<SFXScript>();
        SFX.presentsAlive++;
    }
    private void Update()
    {
        if (isResetted)
        {
            isResetted = false;
        }
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
        SFX.presentsAlive--;
        SFX.PlaySound("presentBreak");
        Destroy(gameObject);
    }
}

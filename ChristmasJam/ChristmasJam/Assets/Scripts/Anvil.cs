using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
    [SerializeField] AudioSource anvilSound;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 5)
        {
            anvilSound.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grinch : MonoBehaviour
{
    [SerializeField] string nextScene;

    private SFXScript SFX;
    private void Start()
    {
        SFX = GameObject.Find("SFX").GetComponent<SFXScript>();
    }
    private void Update()
    {

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Anvil"))
        {
            Die();
        }
    }
    private void Die()
    {
        if (SFX != null)
        {
            SFX.PlaySound("grinchDeath");

        }
        SceneManager.LoadScene(nextScene);
        Destroy(gameObject);
    }
}

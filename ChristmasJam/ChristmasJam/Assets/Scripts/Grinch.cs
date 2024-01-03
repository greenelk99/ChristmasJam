using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grinch : MonoBehaviour
{
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
        if (collision.gameObject.CompareTag("Anvil"))
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Grinch is dead!");
        SceneManager.LoadScene("Level 2");
        Destroy(gameObject);
    }
}

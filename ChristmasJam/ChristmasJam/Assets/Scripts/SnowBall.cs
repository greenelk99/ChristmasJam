using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnowBall : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Rigidbody2D hook;
    [SerializeField] GameObject nextBall;
    [SerializeField] AudioSource firstHitSound;
    [SerializeField] float unHookTime = 0.15f;
    [SerializeField] float maxDragDistance = 3f;
    [SerializeField] string thisScene;

    private bool isFirstHit = true;
    private bool isUnHooked = false;

    private bool mouseDown = false;
    void Start()
    {
        isFirstHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        rb.isKinematic = mouseDown;
        if(mouseDown)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                rb.position = hook.position + ((mousePos - hook.position).normalized * maxDragDistance);
            }
            else
            {
                rb.position = mousePos;
            }
        }
    }

    private void OnMouseDown()
    {
        mouseDown = true;
    }
    private void OnMouseUp()
    {
        mouseDown = false;
        StartCoroutine(UnHook());
    }

    IEnumerator UnHook()
    {
        yield return new WaitForSeconds(unHookTime);
        GetComponent<SpringJoint2D>().enabled = false;
        isUnHooked = true;
        yield return new WaitForSeconds(0.5f);
        if (nextBall != null)
        {
            nextBall.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(thisScene);
        }
        this.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFirstHit && isUnHooked)
        {
            firstHitSound.Play();
            isFirstHit = false;
        }
    }
}

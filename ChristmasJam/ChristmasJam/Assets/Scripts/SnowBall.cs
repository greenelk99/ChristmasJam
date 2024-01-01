using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Rigidbody2D hook;
    [SerializeField] GameObject nextBall;
    [SerializeField] float unHookTime = 0.15f;
    [SerializeField] float maxDragDistance = 3f;

    private bool mouseDown = false;
    void Start()
    {
        
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

        yield return new WaitForSeconds(2);
        if (nextBall != null)
        {
            nextBall.SetActive(true);
        }
        this.enabled = false;
    }
}

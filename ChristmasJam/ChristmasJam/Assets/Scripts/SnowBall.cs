using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Rigidbody2D hook;
    [SerializeField] float unHookTime = 0.15f;
    [SerializeField] float maxDragDistance;

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

            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
        this.enabled = false;
    }
}

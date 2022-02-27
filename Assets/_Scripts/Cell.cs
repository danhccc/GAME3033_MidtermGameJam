using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cell : MonoBehaviour
{
    [SerializeField]
    private bool isMoving = false;

    [SerializeField] private float moveSpeed = 1.0f;
    
    [SerializeField] private float waitTimeBeforeFall = 1.0f;

    public PLATFORMTYPE platformType;

    public Material ZMaterial;
    public Material XMaterial;
    public Material YMaterial;
    public Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        SetMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    public void Move()
    {
        StartCoroutine("moveNow");
    }

    IEnumerator moveNow()
    {
        yield return new WaitForSeconds(waitTimeBeforeFall);
        
        Vector3 originalPos = transform.position;
        if (isMoving == false)
        {
            isMoving = true;
        }
        
    }

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = this.transform;
            Move();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
            Debug.Log("Exit");
            StartCoroutine("StopNow");
        }
    }
    IEnumerator StopNow()
    {
        yield return new WaitForSeconds(0.5f);
        isMoving = false;
    }
    private void MovePlatform()
    {
        if (isMoving)
        {
            switch (platformType)
            {
                case PLATFORMTYPE.VERTICAL:
                    transform.position = transform.position + new Vector3(0, Time.deltaTime * moveSpeed,0);
                    break;
                case PLATFORMTYPE.XAXIS:
                    transform.position = transform.position + new Vector3(Time.deltaTime * moveSpeed, 0,0);
                    break;
                case PLATFORMTYPE.YAXIS:
                    transform.position = transform.position + new Vector3(0,0,Time.deltaTime * moveSpeed);
                    break;
                default:
                    break;
            }
        }
    }

    public void SetMaterial()
    {

        switch (platformType)
        {
            case PLATFORMTYPE.VERTICAL:
                render.material = ZMaterial;
                break;
            case PLATFORMTYPE.XAXIS:
                render.material = XMaterial;
                break;
            case PLATFORMTYPE.YAXIS:
                render.material = YMaterial;
                break;
        }
    }
}

public enum PLATFORMTYPE
{
    VERTICAL,
    XAXIS,
    YAXIS,
}
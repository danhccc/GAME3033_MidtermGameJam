using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private bool isMoving = false;

    [SerializeField] private float moveSpeed;

    public PLATFORMTYPE platformType;
    // Start is called before the first frame update
    void Start()
    {
        
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
        yield return new WaitForSeconds(1.0f);
        
        Vector3 originalPos = transform.position;
        if (isMoving == false)
        {
            isMoving = true;
        }

        yield return new WaitForSeconds(3.0f);
        isMoving = false;
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
        }
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
                    transform.position = transform.position + new Vector3(0, Time.deltaTime * moveSpeed,0);
                    break;
                default:
                    break;
            }
        }
    }
}


public enum PLATFORMTYPE
{
    VERTICAL,
    XAXIS,
    YAXIS,
}
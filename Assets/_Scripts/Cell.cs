using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private bool isSinking = false;

    [SerializeField] private float sinkSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSinking)
        {
            Vector3 newPos;
            newPos.x = transform.position.x;
            newPos.y = -Time.deltaTime * sinkSpeed;
            newPos.z = transform.position.z;

            transform.position = transform.position
                -new Vector3(0, Time.deltaTime * sinkSpeed,0);
        }
    }

    public void Sink()
    {
        StartCoroutine("SinkNow");
    }

    IEnumerator SinkNow()
    {
       
        
        yield return new WaitForSeconds(1.0f);
        
        Vector3 originalPos = transform.position;
        if (isSinking == false)
        {
            isSinking = true;
        }

        yield return new WaitForSeconds(3.0f);
        isSinking = false;
        //transform.position = originalPos;
        //this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = this.transform;
            Debug.Log("sinking");
            Sink();
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
}

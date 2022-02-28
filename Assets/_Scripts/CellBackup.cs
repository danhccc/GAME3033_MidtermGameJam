// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// 
// 
// public class Cell : MonoBehaviour
// {
//     [SerializeField]
//     private bool isBlocked = false;
// 
//     [SerializeField]
//     private bool isMoving = false;
// 
//     [SerializeField] private float moveSpeed = 1.0f;
// 
//     [SerializeField] private float waitTimeBeforeFall = 0.5f;
// 
//     private Vector3 originPosition;
//     private Vector3 originScale;
// 
//     public PLATFORMTYPE platformType;
// 
//     private Rigidbody rigid;
// 
//     public Material ZMaterial;
//     public Material XMaterial;
//     public Material YMaterial;
//     public Renderer render;
// 
//     // Start is called before the first frame update
//     void Start()
//     {
//         originPosition = transform.position;
//         originScale = transform.localScale;
//         rigid = GetComponent<Rigidbody>();
//         render = GetComponent<Renderer>();
//         SetMaterial();
//     }
// 
//     // Update is called once per frame
//     void Update()
//     {
//         MovePlatform();
//     }
// 
//     public void Move()
//     {
//         StartCoroutine("moveNow");
//     }
// 
//     IEnumerator moveNow()
//     {
//         yield return new WaitForSeconds(waitTimeBeforeFall);
//         isMoving = true;
// 
//         //         if (isMoving == false)
//         //         {
//         //             isMoving = true;
//         //         }
//     }
// 
// 
// 
//     private void OnCollisionEnter(Collision other)
//     {
//         if (other.gameObject.CompareTag("Cell"))
//         {
//             isBlocked = true;
//             return;
//         }
//         if (other.gameObject.tag == "Player")
//         {
//             other.transform.parent = this.transform;
//             Move();
//         }
// 
//     }
// 
// 
//     private void OnCollisionExit(Collision other)
//     {
//         if (other.gameObject.tag == "Player")
//         {
//             other.transform.parent = null;
//             StartCoroutine("StopNow");
//         }
// 
//         if (other.gameObject.CompareTag("Cell"))
//         {
//             other.transform.parent = null;
//             isBlocked = false;
//             return;
//         }
//     }
//     IEnumerator StopNow()
//     {
//         yield return new WaitForSeconds(0.5f);
//         isMoving = false;
//     }
// 
// 
//     private void MovePlatform()
//     {
//         if (isMoving)
//         {
//             //if (isBlocked) return;
//             switch (platformType)
//             {
//                 case PLATFORMTYPE.YAXIS:
//                     transform.position = transform.position + new Vector3(0, Time.deltaTime * moveSpeed, 0);
//                     break;
//                 case PLATFORMTYPE.XAXIS:
//                     transform.position = transform.position + new Vector3(Time.deltaTime * moveSpeed, 0, 0);
//                     break;
//                 case PLATFORMTYPE.ZAXIS:
//                     transform.position = transform.position + new Vector3(0, 0, Time.deltaTime * moveSpeed);
//                     //transform.localScale = new Vector3(Time.deltaTime /10, originScale.y, Time.deltaTime/10);
//                     break;
//                 default:
//                     break;
//             }
//         }
//     }
// 
//     public void SetMaterial()
//     {
// 
//         switch (platformType)
//         {
//             case PLATFORMTYPE.YAXIS:
//                 render.material = ZMaterial;
//                 break;
//             case PLATFORMTYPE.XAXIS:
//                 render.material = XMaterial;
//                 break;
//             case PLATFORMTYPE.ZAXIS:
//                 render.material = YMaterial;
//                 break;
//         }
//     }
// }
// 
// public enum PLATFORMTYPE
// {
//     YAXIS,
//     XAXIS,
//     ZAXIS,
// }
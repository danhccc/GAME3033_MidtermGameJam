using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayGround : MonoBehaviour
{
    [SerializeField] private float cellLength = 4;

    [SerializeField] private float cellWidth = 4;
    
    [SerializeField] private float groundLength;
    
    [SerializeField] private float groundWidth;

    [SerializeField] private GameObject cellPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCells();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCells()
    {
        for (int i = 0; i < groundLength; i++)
        {
            for (int j = 0; j < groundWidth; j++)
            {
                Instantiate(cellPrefab,new Vector3(cellLength * i,0,cellWidth * j),Quaternion.identity);
            }
        }
    }
}

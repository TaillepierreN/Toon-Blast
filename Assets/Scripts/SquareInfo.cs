using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareInfo : MonoBehaviour
{
    [SerializeField] string color;
    public int columnSpawned;
    SpawnManager spawner;
    private void Start()
    {
        spawner = GameObject.Find("GameManager").GetComponent<SpawnManager>();
    }
    private void OnDisable()
    {
        switch (columnSpawned)
        {
            case 1:
                spawner.stackedCol1--;
                break;
            case 2:
                spawner.stackedCol2--;
                break;
            case 3:
                spawner.stackedCol3--;
                break;
            case 4:
                spawner.stackedCol4--;
                break;
            default: 
            break;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareInfo : MonoBehaviour
{
    [SerializeField] string color;
    public int columnSpawned;
    Spawner spawner;
    private void Start()
    {
        spawner = GameObject.Find("GameManager").GetComponent<Spawner>();
    }
    private void OnDisable()
    {
        switch (columnSpawned)
        {
            case 1:
                spawner.stackCol1--;
                break;
            case 2:
                spawner.stackCol2--;
                break;
            case 3:
                spawner.stackCol3--;
                break;
            case 4:
                spawner.stackCol4--;
                break;
            default: return;
        }
    }
}


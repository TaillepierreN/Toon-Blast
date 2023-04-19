using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] cols;
    [SerializeField] GameObject[] cubes;
    public int stackCol1;
    public int stackCol2;
    public int stackCol3;
    public int stackCol4;
    bool firstInstantiationDone;

    void Start()
    {
        firstInstantiationDone = false;
        StartCoroutine("FirstInstantiation");
    }


    void Update()
    {
        if (firstInstantiationDone)
        {
            if (stackCol1 < 8) SpawnSquare(0);
            if (stackCol2 < 8) SpawnSquare(1);
            if (stackCol3 < 8) SpawnSquare(2);
            if (stackCol4 < 8) SpawnSquare(3);
        }
    }
    IEnumerator FirstInstantiation()
    {
        for (int i = 0; i < cols.Length; i++)
        {
            for (int y = 0; y < 8; y++)
            {
                SpawnSquare(i);
                yield return new WaitForSeconds(0.1f);
            }
        }
        firstInstantiationDone = true;
    }
    private GameObject SpawnSquare(int index)
    {
        switch (index)
        {
            case 0:
                stackCol1++;
                break;
            case 1:
                stackCol2++;
                break;
            case 2:
                stackCol3++;
                break;
            case 3:
                stackCol4++;
                break;
        }
        GameObject squareSpawned = Instantiate(cubes[Random.Range(0, 5)], cols[index].position, Quaternion.identity);
        squareSpawned.GetComponent<SquareInfo>().columnSpawned = index + 1;
        return squareSpawned;
    }
}

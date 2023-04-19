using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] cols;
    [SerializeField] GameObject[] cubes;
    [SerializeField] Transform poolDepot;
    public List<GameObject> poolCol1;
    public List<GameObject> poolCol2;
    public List<GameObject> poolCol3;
    public List<GameObject> poolCol4;
    GameObject spawnedObject1;
    GameObject spawnedObject2;
    GameObject spawnedObject3;
    GameObject spawnedObject4;
    public int stackedCol1;
    public int stackedCol2;
    public int stackedCol3;
    public int stackedCol4;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            spawnedObject1 = CreateObjects();
            spawnedObject1.SetActive(false);
            poolCol1.Add(spawnedObject1);
            spawnedObject2 = CreateObjects();
            spawnedObject2.SetActive(false);
            poolCol2.Add(spawnedObject2);
            spawnedObject3 = CreateObjects();
            spawnedObject3.SetActive(false);
            poolCol3.Add(spawnedObject3);
            spawnedObject4 = CreateObjects();
            spawnedObject4.SetActive(false);
            poolCol4.Add(spawnedObject4);

        }
        stackedCol1 = 0;
        stackedCol2 = 0;
        stackedCol3 = 0;
        stackedCol4 = 0;
    }

    void Update()
    {
        if (stackedCol1 < 8) StartCoroutine(SpawnSquares(1));
        if (stackedCol2 < 8) StartCoroutine(SpawnSquares(2));
        if (stackedCol3 < 8) StartCoroutine(SpawnSquares(3));
        if (stackedCol4 < 8) StartCoroutine(SpawnSquares(4));
    }
    GameObject CreateObjects()
    {
        return Instantiate(cubes[Random.Range(0, 5)], poolDepot.position, Quaternion.identity);
    }
    IEnumerator SpawnSquares(int column)
    {
        GameObject spawnedSquare = null;
        switch (column)
        {
            case 1:
                spawnedSquare = poolCol1[0];
                spawnedSquare.transform.position = cols[0].position;
                poolCol1.RemoveAt(0);
                poolCol1.Add(spawnedSquare);
                stackedCol1++;
                break;
            case 2:
                spawnedSquare = poolCol2[0];
                spawnedSquare.transform.position = cols[1].position;
                poolCol2.RemoveAt(0);
                poolCol2.Add(spawnedSquare);
                stackedCol2++;

                break;
            case 3:
                spawnedSquare = poolCol3[0];
                spawnedSquare.transform.position = cols[2].position;
                poolCol3.RemoveAt(0);
                poolCol3.Add(spawnedSquare);
                stackedCol3++;
                break;
            case 4:
                spawnedSquare = poolCol4[0];
                spawnedSquare.transform.position = cols[3].position;
                poolCol4.RemoveAt(0);
                poolCol4.Add(spawnedSquare);
                stackedCol4++;
                break;
            default:
                break;
        }
        spawnedSquare.GetComponent<SquareInfo>().columnSpawned = column;
        spawnedSquare.GetComponent<Rigidbody2D>().simulated = true;
        spawnedSquare.SetActive(true);
        yield return new WaitForSeconds(0.5f);

    }
}

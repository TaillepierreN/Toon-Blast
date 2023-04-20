using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] cols;
    [SerializeField] GameObject[] cubes;
    [SerializeField] Transform poolDepot;
    public List<GameObject> commonPool;
    public List<GameObject> toDeletePool;
    GameObject spawnedObject;
    public int stackedCol1;
    public int stackedCol2;
    public int stackedCol3;
    public int stackedCol4;
    bool firstInstantiation;
    int numberOfSquareToCreate;
    private void Awake()
    {
        stackedCol1 = 0;
        stackedCol2 = 0;
        stackedCol3 = 0;
        stackedCol4 = 0;
        numberOfSquareToCreate = 40;
        firstInstantiation = false;
    }
    void Start()
    {
        if (!firstInstantiation)
        {
            for (int i = 0; i < numberOfSquareToCreate; i++)
            {
                spawnedObject = CreateObjects();
                commonPool.Add(spawnedObject);
            }
            firstInstantiation = true;
        }
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
        int rng = Random.Range(0,commonPool.Count);
        spawnedSquare = commonPool[rng];
        commonPool.RemoveAt(rng);
        spawnedSquare.transform.position = cols[column-1].position;
        switch (column)
        {
            case 1:
                stackedCol1++;
                break;
            case 2:
                stackedCol2++;
                break;
            case 3:
                stackedCol3++;
                break;
            case 4:
                stackedCol4++;
                break;
            default:
                break;
        }
        spawnedSquare.GetComponent<SquareBehavior>().ActivateSquare(column);
        yield return new WaitForSeconds(0.5f);
    }

    public void Respawn(int column, GameObject squareObject)
    {
        commonPool.Add(squareObject);
        switch (column)
        {
            case 1:
                stackedCol1--;
                break;
            case 2:
                stackedCol2--;
                break;
            case 3:
                stackedCol3--;
                break;
            case 4:
                stackedCol4--;
                break;
            default: break;
        }
        SpawnSquares(column);
    }
    public void AddToDeletePool(GameObject objToAddToPool)
    {
        toDeletePool.Add(objToAddToPool);
    }
    public IEnumerator DeleteSquares()
    {
        yield return new WaitForSeconds(0.5f);
        foreach(GameObject objToDelete in toDeletePool)
        {
            objToDelete.GetComponent<SquareBehavior>().DisableSquare();
        }
            toDeletePool.Clear();
    }
}

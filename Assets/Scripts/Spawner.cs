using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] cols;
    [SerializeField] GameObject[] cubes;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("firstInstantiation");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator firstInstantiation()
    {
        for (int i = 0; i < cols.Length ; i++)
        {
            for (int y = 0; y < 8; y++)
            {
                GameObject squareSpawned = Instantiate(cubes[Random.Range(0,5)], cols[i].position, Quaternion.identity);
                squareSpawned.GetComponent<SquareInfo>().columnSpawned = i;
                yield return new WaitForSeconds(0.1f);
            }
        }

    }
}

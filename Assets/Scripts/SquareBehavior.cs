using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehavior : MonoBehaviour
{
    [SerializeField] string color;
    public int columnSpawned;
    SpawnManager spawner;
    Rigidbody2D rg;
    private void Awake()
    {
        spawner = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        rg = gameObject.GetComponent<Rigidbody2D>();
    }
    public void DisableSquare(){
        spawner.Respawn(columnSpawned,gameObject);
        rg.simulated = false;
        gameObject.SetActive(false);
    }
    public void ActivateSquare(int col)
    {
        gameObject.SetActive(true);
        columnSpawned = col;
        rg.simulated = true;
    }

    private void OnDisable() {
        
    }
}


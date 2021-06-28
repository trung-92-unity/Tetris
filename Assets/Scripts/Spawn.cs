using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] tetrominoes;
    
    // Start is called before the first frame update
    void Start()
    {
        NewTetromino();
    }

    // Update is called once per frame
    public void NewTetromino()
    {
        Instantiate(tetrominoes[Random.Range(0, tetrominoes.Length)], transform.position, Quaternion.identity);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipespawner : MonoBehaviour 
{
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 2f; 
    private float timer;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > _maxTime)
        {
            timer = 0;
            SpawnPipe();
        }
        
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange), 0);
        GameObject pipe = Instantiate(_pipePrefab, spawnPos, Quaternion.identity);
        Destroy(pipe, 5f);
    }
}
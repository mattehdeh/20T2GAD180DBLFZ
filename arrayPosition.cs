﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrayPosition : MonoBehaviour
{
    // private Vector3[] positionArray = new[] { new Vector3(0f, 0f, 0f), new Vector3(1f, 1f, 1f)};

    public Transform[] spawnlocations;
    public GameObject[] toSpawn;
    public GameObject[] spawnClone;

    private void Start()
    {
        paperRandom();
    }


    void paperRandom()

    {
        int randomLocation = Random.Range(0, spawnlocations.Length);
        spawnClone[0] = Instantiate(toSpawn[0], spawnlocations[randomLocation].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
       
    }
    
}
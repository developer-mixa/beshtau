using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private float _spawnTime;
    [SerializeField] private GameObject lightningObject;

    private void Start()
    {
        StartCoroutine(ThunderSpawn());
    }

    private IEnumerator ThunderSpawn()
    {
        var seconds = new WaitForSeconds(_spawnTime / 2);
        for (;;)
        {
            yield return seconds;
            lightningObject.SetActive(false);
            yield return seconds;
            lightningObject.SetActive(true);
        }
    }
    
}

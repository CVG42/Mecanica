using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    [SerializeField] GameObject star;
    [SerializeField] GameObject sphere;
    [SerializeField] int radius;
    [SerializeField] Vector3 origin; 

    void Update()
    {
        origin = sphere.transform.position;
        Vector3 randomPosition = origin + Random.insideUnitSphere * radius;

        for(int i=0; i<15; i++)
        {
            Instantiate(star, randomPosition, Quaternion.identity);
        }
    }
}

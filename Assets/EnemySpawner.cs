using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyMartian;


    public void SpawnEnemy(GameObject enemy)
    {
        //cant figure out how to instantiate the object facing up
        Instantiate(enemy, this.transform.position,quaternion.RotateZ(90) );
    }
}

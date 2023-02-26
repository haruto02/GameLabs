using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float xMinMax;
    public float zMin;
    public GameObject rock;
    public int count;

    public float startWait;
    public float cloneWait;
    public float waveWait;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());    
    }

    IEnumerator SpawnWaves() {
        while (true) {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < count; i++) {
                Vector3 spawnPosition = new Vector3(Random.Range(-xMinMax, xMinMax), 0, zMin);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(rock, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(cloneWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}

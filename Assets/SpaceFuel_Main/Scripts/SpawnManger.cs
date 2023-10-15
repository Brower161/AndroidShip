using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnTime1;
    [SerializeField] float spawnTime2;
    [SerializeField] float spawnPosY;

    public GameObject[] Spawner;

    public float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(objDrop());

    }

    // Update is called once per frame
    private void spawnSomething()
    {
        //Numero de obj aleartorio
        int num = Random.Range(0, Spawner.Length);
        Vector3 randomPos = new Vector3(transform.position.x, Random.Range(-spawnPosY, spawnPosY), transform.position.z);
        GameObject g = Instantiate(Spawner[num], randomPos, Quaternion.identity);
        respawnTime = Random.Range(spawnTime1, spawnTime2);
    }
    IEnumerator objDrop()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            spawnSomething();
        }

    }

}

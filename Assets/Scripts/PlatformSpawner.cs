using UnityEngine;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformChunks;
    public Transform player;
    public float spawnDistance = 50f;
    public float despawnDistance = 30f;
    public float chunkLength = 20f;

    private List<GameObject> activeChunks = new List<GameObject>();
    private float nextSpawnZ = 0f;

    void Start()
    {
        // Başlangıçta 5 chunk oluştur
        for (int i = 0; i < 5; i++)
        {
            SpawnChunk();
        }
    }

    void Update()
    {
        if (player == null) return;

        // Önde chunk oluştur
        if (player.position.z + spawnDistance > nextSpawnZ)
        {
            SpawnChunk();
        }

        // Arkada chunk sil
        for (int i = activeChunks.Count - 1; i >= 0; i--)
        {
            if (activeChunks[i].transform.position.z < player.position.z - despawnDistance)
            {
                Destroy(activeChunks[i]);
                activeChunks.RemoveAt(i);
            }
        }
    }

    void SpawnChunk()
    {
        if (platformChunks.Length == 0) return;

        int index = Random.Range(0, platformChunks.Length);
        GameObject chunk = Instantiate(platformChunks[index], new Vector3(0, 0, nextSpawnZ), Quaternion.identity);
        activeChunks.Add(chunk);
        nextSpawnZ += chunkLength;
    }
}
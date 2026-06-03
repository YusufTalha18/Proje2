using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  public GameObject[] obstaclePrefabs;
    public float spawnInterval = 5f;
    public float laneDistance = 3f;
    public Transform player;

    private float timer;

    void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnObstacle();
        }
    }
    
    void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0) return;

        // Rastgele şerit seç (0, 1, 2)
        int lane = Random.Range(0, 3);
        float xPos = (lane - 1) * laneDistance;

        // Karakterin önünde spawn et
        float zPos = player.position.z + 30f;

        int index = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[index], new Vector3(xPos, 0.5f, zPos), Quaternion.identity);
    }
}

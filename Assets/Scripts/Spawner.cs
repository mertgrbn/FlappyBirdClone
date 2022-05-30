using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f; 
    public float minHeight = -1f;  // Spawnlanacak objemizin min ve max yüksekliğini belirliyoruz.
    public float maxHeight = 1f;
    private void OnEnable() // Objemizi spawnlıyoruz.
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    private void OnDisable() // Objemizi spawnlamasını durdurmasını söylüyoruz
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn() // Spawnlanacak objemizin ne olduğunu ve hangi konumlarda spawnlanacağını bildiriyoruz.
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight); // Objemizin rastgele bir şekilde aşağıda veya yukarıda spawnlanmasını söylüyoruz.

    }
}

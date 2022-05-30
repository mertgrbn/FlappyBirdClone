using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;
    private void Start() 
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; // Objemiz kamera açısından çıktıktan 1 birim sonra yok edilecektir.
    }
    private void Update() 
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // Sol tarafa doğru belirlediğimiz hızda ilerlemesini sağlıyoruz.

        if (transform.position.x < leftEdge) 
        {
            Destroy(gameObject);  // Objemiz sol kenardan bırakılırsa yok edilecek.
        }
    }
}

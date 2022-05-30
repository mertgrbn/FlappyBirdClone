using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start() 
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        
    }
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // Karakter aşağı düşmeye başladığında space veya mouse tuşu ile havaya sıçramasını sağlar.
        {
            direction = Vector3.up * strength; // Karakterin yukarıya ne kadar güçle çıkacağını ayarlar.
        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Mobil için ekrana kaç defa dokunduğu referansını verir.

            if(touch.phase ==   TouchPhase.Began) // Ekrana yeni bir dokunma girişi yaptım.
            {
                direction = Vector3.up * strength;
            }
        }
        direction.y += gravity * Time.deltaTime; // Sadece y yönü için yer çekimini ayarlıyoruz.
        transform.position += direction * Time.deltaTime; 
    }
    private void AnimateSprite() // Karakterin 3 farklı şeklini seçmemizi ve  animasyonunu oluşturmamızı sağlıyor.
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D other)  // Karakterin Objeye çarptığında Oyunu bitirir.
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
        
    }
}

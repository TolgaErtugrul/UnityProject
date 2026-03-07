using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab; // Üretilecek obje kalıbı
    [SerializeField] private float spawnInterval = 2.0f; // Kaç saniyede bir üretilsin?
    
    [SerializeField] private float spawnRangeX = 10f; // Hangi genişlikte üretilsin?

    void Start()
    {
        // "SpawnCoin" fonksiyonunu 1 saniye sonra başlat ve her 'spawnInterval'da bir tekrarla
        InvokeRepeating("SpawnCoin", 1.0f, spawnInterval);
    }

    void SpawnCoin()
    {
        // Rastgele bir pozisyon belirle
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(randomX, 1, 10); // X ekseni rastgele, Z sabit 10

        // Obje üretme komutu: Instantiate(ne, nerede, hangi açıyla)
        Instantiate(coinPrefab, spawnPos, Quaternion.identity);
    }

    public void IncreaseDifficulty(float amount)
    {
        // Spawn aralığını düşürerek objelerin daha sık gelmesini sağlarız
        spawnInterval -= amount;
        if (spawnInterval < 0.5f) spawnInterval = 0.5f; // Çok imkansız olmasın diye sınır koyduk
        
        // Eski döngüyü durdurup yeni hızla başlatalım
        CancelInvoke("SpawnCoin");
        InvokeRepeating("SpawnCoin", spawnInterval, spawnInterval);
    }
}

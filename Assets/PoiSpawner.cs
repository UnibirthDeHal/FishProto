using UnityEngine;
using System.Collections;

public class PoiSpawner : MonoBehaviour
{
    public GameObject poiPrefab; // Poiプレハブへの参照
    public float spawnInterval = 3f; // 生成する間隔（秒）
    private float nextSpawnTime;

    // 生成位置の範囲を設定
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 3f;

    void Start()
    {
        // 最初の生成をスケジュールする
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        // 現在の時間が次の生成時間を超えたかチェック
        if (Time.time >= nextSpawnTime)
        {
            // ランダムな位置を生成
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // Poiプレハブをランダムな位置に生成
            if (poiPrefab != null) // プレハブがnullでないことを確認
            {
                // オブジェクト自身を生成する
                Instantiate(gameObject, spawnPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("ポイプレハブが指定されていません。");
            }

            // 次の生成時間を更新
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}

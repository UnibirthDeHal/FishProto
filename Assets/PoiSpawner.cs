using UnityEngine;
using System.Collections;

public class PoiSpawner : MonoBehaviour
{
    public GameObject poiPrefab; // Poi�v���n�u�ւ̎Q��
    public float spawnInterval = 3f; // ��������Ԋu�i�b�j
    private float nextSpawnTime;

    // �����ʒu�͈̔͂�ݒ�
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 3f;

    void Start()
    {
        // �ŏ��̐������X�P�W���[������
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        // ���݂̎��Ԃ����̐������Ԃ𒴂������`�F�b�N
        if (Time.time >= nextSpawnTime)
        {
            // �����_���Ȉʒu�𐶐�
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // Poi�v���n�u�������_���Ȉʒu�ɐ���
            if (poiPrefab != null) // �v���n�u��null�łȂ����Ƃ��m�F
            {
                // �I�u�W�F�N�g���g�𐶐�����
                Instantiate(gameObject, spawnPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("�|�C�v���n�u���w�肳��Ă��܂���B");
            }

            // ���̐������Ԃ��X�V
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}

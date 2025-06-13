using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonFakeObjSpawner : MonoBehaviour
{
    [SerializeField] private GameObject nonFakeObjPrefab;
    [SerializeField] private int _poolSize = 10;
    [SerializeField] private BoxCollider spawnerArea;

    private ObjectPool _objectPool;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (spawnerArea == null)
            spawnerArea = GetComponent<BoxCollider>();

        _objectPool = new ObjectPool(_poolSize, nonFakeObjPrefab, gameObject);
    }

    private void Start()
    {
        SpawnAllNonFakeObjects();
    }
    private void OnDestroy()
    {
        _objectPool?.DestroyAll();
    }


    // 랜덤 위치 반환
    private Vector3 GetRandomPositionInArea()
    {
        Vector3 center = spawnerArea.bounds.center;
        Vector3 size = spawnerArea.bounds.size;

        float randomX = Random.Range(-size.x / 2, size.x / 2);
        float randomZ = Random.Range(-size.z / 2, size.z / 2);

        Vector3 spawnPos = new Vector3(center.x + randomX, center.y + 1f, center.z + randomZ);
        return spawnPos;
    }

    public void SpawnAllNonFakeObjects()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = _objectPool.GetPooledObject();
            if (obj != null)
            {
                obj.transform.position = GetRandomPositionInArea();
                obj.SetActive(true);

                FakeObject fake = obj.GetComponent<FakeObject>();
                if (fake != null)
                    fake.isFake = false;
            }
        }
    }
}
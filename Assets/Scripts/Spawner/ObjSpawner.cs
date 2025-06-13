using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    #region SerializeField
    [SerializeField] private GameObject nonFakeObjPrefab;
    [SerializeField] private int _poolSize = 15;
    [SerializeField] private int _fakeObj = 3;
    [SerializeField] private BoxCollider spawnerArea;
    #endregion


    private ObjectPool _objectPool;
    #region MonoBehaviour
    private void Awake()
    {
        Init();
    }
    private void Start()
    {
        GameManager.Instance.ChangeGameState(GameState.Preview);
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
    }
    private void OnDestroy()
    {
        _objectPool?.DestroyAll();
    }
    #endregion

    private void HandleGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Preview:
                SpawnObjects(isFake: false, count: _poolSize - _fakeObj);
                break;

            case GameState.Playing:
                SpawnObjects(isFake: true, count: _fakeObj);
                break;
        }
    }



    private void Init()
    {
        if (spawnerArea == null)
            spawnerArea = GetComponent<BoxCollider>();

        _objectPool = new ObjectPool(_poolSize, nonFakeObjPrefab, gameObject);
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

    public void SpawnObjects(bool isFake, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = _objectPool.GetPooledObject();
            if (obj != null)
            {
                obj.transform.position = GetRandomPositionInArea();
                obj.SetActive(true);

                FakeObject fake = obj.GetComponent<FakeObject>();
                if (fake != null)
                    fake.isFake = isFake;
            }
        }
    }
}
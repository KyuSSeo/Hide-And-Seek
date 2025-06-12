using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonFakeObjSpawner : MonoBehaviour
{
    [SerializeField] public GameObject NonFakeObjPrefab;
    [SerializeField] private BoxCollider SpawnerArea;

    private void Awake() => Init();

    private void Init()
    {
        SpawnerArea = NonFakeObjPrefab.GetComponent<BoxCollider>();
    }

    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    //  랜덤한 좌표를 반환하는 함수
    private Vector3 SetRandomPos()
    {
        Vector3 pos = NonFakeObjPrefab.transform.position;

        float range_x = SpawnerArea.bounds.size.x;
        float range_z = SpawnerArea.bounds.size.z;

        range_x = Random.Range((range_x/2) * -1, range_x/2); 
        range_z = Random.Range((range_z / 2) * -1, range_z / 2);

        Vector3 randomPos = new Vector3(range_x, 0, range_z);

        Vector3 SpawnPos = pos + randomPos;
        return SpawnPos;
    }


    private IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            GameObject instantCapsul = Instantiate(NonFakeObjPrefab, SetRandomPos(), Quaternion.identity);
        }
    }
}

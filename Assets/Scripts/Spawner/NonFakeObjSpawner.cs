using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonFakeObjSpawner : MonoBehaviour
{
    [SerializeField] public GameObject NonFakeObjPrefab;
    [SerializeField] private BoxCollider SpawnerArea;

    // 게임 메니저의 상태 State를 참조하여 상태에 따른 생성 시 프리팹 진위여부 결정


    private void Awake() => Init();

    private void Init()
    {
        SpawnerArea = SpawnerArea.GetComponent<BoxCollider>();
    }

    private void Start()
    {
        StartCoroutine(RandomRespawnCoroutine());
    }

    //  랜덤한 좌표를 반환하는 함수
    private Vector3 SetRandomPos()
    {
        Vector3 pos = NonFakeObjPrefab.transform.position;

        float range_x = SpawnerArea.bounds.size.x;
        float range_z = SpawnerArea.bounds.size.z;

        range_x = Random.Range((range_x/2) * -1, range_x/2); 
        range_z = Random.Range((range_z / 2) * -1, range_z / 2);

        Vector3 randomPos = new Vector3(range_x, 1, range_z);

        Vector3 SpawnPos = randomPos;
        return SpawnPos;
    }

    //  코루틴으로 생성하는게 맞나?
    private IEnumerator RandomRespawnCoroutine()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Vector3 pos = SetRandomPos();
            GameObject obj = Instantiate(NonFakeObjPrefab, pos, Quaternion.identity);

            FakeObject fakeObj = obj.GetComponent<FakeObject>();
            if (fakeObj != null)
            {
                fakeObj.isFake = false;
            }
        }
    }
}

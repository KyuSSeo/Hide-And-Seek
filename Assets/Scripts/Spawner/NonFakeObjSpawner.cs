using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonFakeObjSpawner : MonoBehaviour
{
    [SerializeField] public GameObject NonFakeObjPrefab;
    [SerializeField] private BoxCollider SpawnerArea;

    // ���� �޴����� ���� State�� �����Ͽ� ���¿� ���� ���� �� ������ �������� ����


    private void Awake() => Init();

    private void Init()
    {
        SpawnerArea = SpawnerArea.GetComponent<BoxCollider>();
    }

    private void Start()
    {
        StartCoroutine(RandomRespawnCoroutine());
    }

    //  ������ ��ǥ�� ��ȯ�ϴ� �Լ�
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

    //  �ڷ�ƾ���� �����ϴ°� �³�?
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

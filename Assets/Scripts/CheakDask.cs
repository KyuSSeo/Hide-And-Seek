using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheakDask : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {
        var fake = other.GetComponent<FakeObject>();
        if (fake != null)
        {
            if (fake.isFake)
            {
                Debug.Log("�̰� ��¥��");
                GameManager.Instance.AddScore();
            }
            else
            {
                Debug.Log("�̰� ���� �ִ� ������Ʈ��");
                GameManager.Instance.FailAttempt();
            }

            // ������Ʈ ���� or ���� ��ġ�� �ǵ�����
            Destroy(other.gameObject);
        }
    }
}

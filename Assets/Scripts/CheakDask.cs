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
                Debug.Log("이건 가짜야");
                GameManager.Instance.AddScore();
            }
            else
            {
                Debug.Log("이건 원래 있던 오브잭트야");
                GameManager.Instance.FailAttempt();
            }

            // 오브젝트 삭제 or 원래 위치로 되돌리기
            Destroy(other.gameObject);
        }
    }
}

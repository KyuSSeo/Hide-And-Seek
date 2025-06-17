using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheakDask : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.State == GameState.Preview)
            return;

        var fake = other.GetComponent<FakeObject>();
        if (fake != null)
        {
            if (fake.isFake)
            {
                GameManager.Instance.Score.AddScore();
            }
            else
            {
                GameManager.Instance.Score.FailAttempt();
            }

            other.gameObject.SetActive(false);
        }
    }
}

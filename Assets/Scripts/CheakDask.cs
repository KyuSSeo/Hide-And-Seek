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
                Debug.Log("����!");
            }
            else
            {
                Debug.Log("����!");
            }

            other.gameObject.SetActive(false);
        }
    }
}

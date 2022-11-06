using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}

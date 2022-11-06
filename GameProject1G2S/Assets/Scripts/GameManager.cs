using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject shelterPrefab;
    [SerializeField] private int groundAmount;
    private List<GameObject> grounds;

    private void Start()
    {
        for (int i = 1; i <= groundAmount; i++)
        {
            Instantiate(groundPrefab, new Vector2(groundPrefab.transform.localScale.x * i, groundPrefab.transform.position.y), Quaternion.identity);
        }

        Instantiate(shelterPrefab, new Vector2(groundPrefab.transform.localScale.x * groundAmount + groundPrefab.transform.localScale.x * 0.5f - shelterPrefab.transform.localScale.x * 0.5f, shelterPrefab.transform.position.y), Quaternion.identity); ;
    }
}

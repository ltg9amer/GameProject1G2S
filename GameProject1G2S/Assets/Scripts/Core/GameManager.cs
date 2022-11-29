using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> gimmicks;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject shelterPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private Slider progressSlider;
    [SerializeField] private int groundAmount;
    private BoxCollider2D shelterCollider;
    private float startDistance;
    private float currentDistance;

    private void Start()
    {
        for (int i = 0; i <= groundAmount; i++)
        {
            GameObject ground = Instantiate(groundPrefab, new Vector2(groundPrefab.transform.localScale.x * i, groundPrefab.transform.position.y), Quaternion.identity);
            ground.name = $"Ground {i}";

            if (i > 0)
            {
                GameObject gimmick = Instantiate(gimmicks[i - 1], new Vector2(groundPrefab.transform.localScale.x * i, gimmicks[i - 1].transform.position.y), Quaternion.identity);

                gimmick.transform.SetParent(ground.transform);
                gimmick.SetActive(false);
            }
        }

        shelterCollider = Instantiate(shelterPrefab, new Vector2(groundPrefab.transform.localScale.x * groundAmount + groundPrefab.transform.localScale.x * 0.5f + shelterPrefab.transform.localScale.x * 0.325f, shelterPrefab.transform.position.y), Quaternion.identity).GetComponent<BoxCollider2D>();
        shelterCollider.name = "Shelter";
        startDistance = Vector2.Distance(player.transform.position, shelterCollider.transform.position - new Vector3(shelterCollider.transform.localScale.x * 0.345f, 5f));
    }

    private void Update()
    {
        currentDistance = Vector2.Distance(player.transform.position, shelterCollider.transform.position - new Vector3(shelterCollider.transform.localScale.x * 0.345f, 5f));

        if (progressSlider.value < 0.99f)
        {
            progressSlider.value = (startDistance - currentDistance) / startDistance;
        }
        else
        {
            progressSlider.value = progressSlider.maxValue;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject shelterPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private Slider progressSlider;
    [SerializeField] private int groundAmount;
    private PolygonCollider2D shelterCollider;
    private float startDistance;
    private float currentDistance;

    private void Start()
    {
        for (int i = 1; i <= groundAmount; i++)
        {
            Instantiate(groundPrefab, new Vector2(groundPrefab.transform.localScale.x * i, groundPrefab.transform.position.y), Quaternion.identity);
        }

        shelterCollider = Instantiate(shelterPrefab, new Vector2(groundPrefab.transform.localScale.x * groundAmount + groundPrefab.transform.localScale.x * 0.5f - shelterPrefab.transform.localScale.x * 0.5f, shelterPrefab.transform.position.y), Quaternion.identity).GetComponent<PolygonCollider2D>();
        startDistance = Vector2.Distance(player.transform.position, shelterCollider.transform.position);
    }

    private void Update()
    {
        currentDistance = Vector2.Distance(player.transform.position, shelterCollider.transform.position);

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

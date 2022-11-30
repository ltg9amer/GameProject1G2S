using UnityEngine;

public class CrowdMove : MonoBehaviour, IGimmick
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private string deathName;
    private GameEndProcess gameEndProcess;

    private void Awake()
    {
        gameEndProcess = GameObject.Find("Player").GetComponent<GameEndProcess>();
    }

    private void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CheckExperience();
        }
    }

    public void CheckExperience()
    {
        try
        {
            Death death = null;

            if (death = DeathCollection.instance.transform.GetChild(0).GetChild(0).Find(deathName).GetComponent<Death>())
            {
                death.experience = true;
                gameEndProcess.DeathName = deathName;

                PlayerPrefs.SetInt(deathName, death.experience ? 1 : 0);
            }
        }
        catch
        {
            Debug.LogError("해당하는 죽음이 존재하지 않습니다");
        }
    }
}

using UnityEngine;

public class IronManGimmick : MonoBehaviour, IGimmick
{
    [SerializeField] private string deathName;
    private GameEndProcess gameEndProcess;
    private bool isCheck;

    private void Awake()
    {
        gameEndProcess = GameObject.Find("Player").GetComponent<GameEndProcess>();
    }

    private void OnEnable()
    {
        Destroy(transform.parent.gameObject, 2f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCheck)
        {
            isCheck = !isCheck;

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

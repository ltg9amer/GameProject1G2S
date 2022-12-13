using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndProcess : MonoBehaviour
{
    private delegate void OnEnd<T>(T endKey);

    public static Death death;
    private OnEnd<string> onDead;
    private OnEnd<bool> onClear;
    private bool isEnd;
    private bool isClear;
    public bool IsClear
    {
        get { return isClear; }
        set
        {
            if (!isEnd)
            {
                isClear = value;

                onClear(isClear);
            }
        }
    }
    private string deathName;
    public string DeathName
    {
        get { return deathName; }
        set
        {
            if (!isClear)
            {
                deathName = value;

                onDead(deathName);
            }
        }
    }

    private void Start()
    {
        onDead = deathKey =>
        {
            isEnd = true;
            death = DeathCollection.instance.transform.GetChild(0).GetChild(0).Find(deathKey).GetComponent<Death>();

            SceneManager.LoadScene("GameOverScene");

        };

        onClear = clearKey =>
        {
            isEnd = clearKey;

            SceneManager.LoadScene("GameClearScene");
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shelter"))
        {
            IsClear = true;
        }
    }
}

using System;
using UnityEngine;

public class CrowdMove : MonoBehaviour, IGimmick
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private string deathName;

    private void Awake()
    {
#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#endif
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

            collision.gameObject.GetComponent<GameEndProcess>().DeathName = deathName;
        }
    }

    public void CheckExperience()
    {
        try
        {
            Death death = null;

            if (death = DeathCollection.instance.transform.GetChild(0).Find(deathName).GetComponent<Death>())
            {
                death.experience = true;

                PlayerPrefs.SetInt(deathName, death.experience ? 1 : 0);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}

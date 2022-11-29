using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DeathCollection : MonoBehaviour
{
    public static DeathCollection instance;

    [SerializeField] private List<Image> deathImages;
    private List<Death> deaths;

    private void Awake()
    {
#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
#endif

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        if (deaths != null)
        {
            for (int i = 0; i < deaths.Count; i++)
            {
                if (deaths[i].experience)
                {
                    deathImages[i].color = Color.white;
                }
            }
        }
    }

    private void Start()
    {
        deaths = transform.GetChild(0).GetChild(0).GetComponentsInChildren<Death>().ToList();

        for (int i = 0; i < deaths.Count; i++)
        {
            deaths[i].experience = PlayerPrefs.GetInt(deaths[i].name, 0) != 0;

            if (deaths[i].experience)
            {
                deathImages[i].color = Color.white;
            }
        }

        gameObject.SetActive(false);
    }
}

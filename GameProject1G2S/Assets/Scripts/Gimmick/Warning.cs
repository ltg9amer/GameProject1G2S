using System.Collections;
using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField] private GameObject gimmickObject;
    private SpriteRenderer spriteRenderer;
    private int coroutineCount;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine("WarningToggle");
    }

    private IEnumerator WarningToggle()
    {
        spriteRenderer.enabled = true;

        yield return new WaitForSeconds(1f);

        spriteRenderer.enabled = false;

        yield return new WaitForSeconds(1f);

        coroutineCount++;

        if (coroutineCount == 1)
        {
            StartCoroutine("WarningToggle");
        }
        else
        {
            gimmickObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

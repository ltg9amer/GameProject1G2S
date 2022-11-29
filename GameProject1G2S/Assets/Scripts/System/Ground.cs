using UnityEditor;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    private GameObject nextGround;
    private bool isCheck;

    private void Update()
    {
        Collider2D playerHit = Physics2D.OverlapBox(transform.position + new Vector3(0f, transform.localScale.y), transform.localScale, 0f, playerLayer);

        if (playerHit && !isCheck)
        {
            isCheck = !isCheck;

            nextGround = GameObject.Find($"Ground {int.Parse(gameObject.name.Split(" ")[1]) + 1}");

            if (transform.childCount > 1)
            {
                Warning warning = transform.GetChild(1).GetComponentInChildren<Warning>();

                if (warning)
                {
                    warning.enabled = true;
                }
            }

            if (nextGround != null)
            {
                nextGround.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(0f, transform.localScale.y), transform.localScale);
    }
}

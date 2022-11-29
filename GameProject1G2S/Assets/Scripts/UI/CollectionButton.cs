using UnityEngine;
using UnityEngine.UI;

public class CollectionButton : MonoBehaviour
{
    private Button collectionButton;

    private void Awake()
    {
        collectionButton = GetComponent<Button>();
    }

    private void Start()
    {
        collectionButton.onClick.AddListener(CollectionOpen);
    }

    private void CollectionOpen()
    {
        DeathCollection.instance.gameObject.SetActive(true);
    }
}

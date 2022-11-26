using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject collectionPanel;
    private bool isCollectionOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            OpenCollection();
        }
    }

    public void OpenCollection()
    {
        if (/*!(SceneManager.GetActiveScene().name == "PlayScene")*/true)
        {
            collectionPanel.gameObject.SetActive(!isCollectionOpen);

            isCollectionOpen = !isCollectionOpen;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneButtonManager : MonoBehaviour, IPointerDownHandler
{
    public string sceneName;

    private bool isButtonDown = false;

    private void Update()
    {
        if (isButtonDown)
        {
            Debug.Log("Button Down");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(sceneName);
    }
}

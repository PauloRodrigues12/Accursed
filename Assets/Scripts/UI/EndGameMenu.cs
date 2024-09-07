using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public GameObject endMenu;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            endMenu.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("BaseMap");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
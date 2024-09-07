using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timer;
    public RawImage outlineUI;
    public RawImage backgroundUI;
    public RawImage maxHealth;
    public RawImage healthPoints;

    [Header("Curse Display")]
    public GameObject[] curses;
    private PlayerManager playerManager;
    public OrbPickUp orbPickUp;
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        outlineUI.rectTransform.sizeDelta = new Vector2((playerManager.healthPoints * 3) + 10, outlineUI.rectTransform.sizeDelta.y);
        backgroundUI.rectTransform.sizeDelta = new Vector2(playerManager.healthPoints * 3, backgroundUI.rectTransform.sizeDelta.y);
    }
    void Update()
    {
        timer += Time.deltaTime;

        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        healthPoints.rectTransform.sizeDelta = new Vector2(playerManager.healthPoints * 3, healthPoints.rectTransform.sizeDelta.y);
        maxHealth.rectTransform.sizeDelta = new Vector2(playerManager.maxHealthPoints * 3, maxHealth.rectTransform.sizeDelta.y);

        if (orbPickUp.currentlyHeldOrb != null)
        {
            switch (orbPickUp.currentlyHeldOrb.orbType.color)
            {
                case "Blue":

                    curses[0].SetActive(true);

                    break;
                case "Pink":

                    curses[1].SetActive(true);

                    break;
                case "Yellow":

                    curses[2].SetActive(true);

                    break;
                case "Purple":

                    curses[3].SetActive(true);

                    break;
                case "Green":

                    curses[4].SetActive(true);

                    break;
            }
        }
        else
        {
            for (int i = 0; i < curses.Length; i++)
            {
                if (curses[i] != null)
                {
                    curses[i].SetActive(false);
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timer;
    public RawImage maxHealth;
    public RawImage healthPoints;
    private PlayerManager playerManager;

    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    void Update()
    {
        timer += Time.deltaTime;

        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        healthPoints.rectTransform.sizeDelta = new Vector2(playerManager.healthPoints * 20, healthPoints.rectTransform.sizeDelta.y);
        maxHealth.rectTransform.sizeDelta = new Vector2(playerManager.maxHealthPoints * 20, healthPoints.rectTransform.sizeDelta.y);
    }
}
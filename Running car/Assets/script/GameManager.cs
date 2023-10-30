using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Gameover;
    public Text Playtime;
    public Text Record;

    float surviveTime;
    bool isGameOver;

    void Start()
    {
        surviveTime = 0;
        isGameOver = false;
    }

    void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            Playtime.text = "Time : " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        Gameover.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            // Player Preference (플레이어 설정) : 간단한 방식으로 수치를 로컬(현재 실행 중인 컴퓨터)에 저장하고 나중에 다시 불러오는 메서
        }

        Record.text = "Best Time : " + (int)bestTime;
    }
}

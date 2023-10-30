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
            // Player Preference (�÷��̾� ����) : ������ ������� ��ġ�� ����(���� ���� ���� ��ǻ��)�� �����ϰ� ���߿� �ٽ� �ҷ����� �޼�
        }

        Record.text = "Best Time : " + (int)bestTime;
    }
}

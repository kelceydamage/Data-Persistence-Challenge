using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameObject;
    [SerializeField] private TextMeshProUGUI highScoreObject;

   void Start()
    {
        GetHighScore();
        GetPlayerName();
    }
    private void SetPlayerName()
    {
        PlayerState.Instance.PlayerName = playerNameObject.text;
    }

    private void GetPlayerName()
    {
        playerNameObject.text = PlayerState.Instance.PlayerName;
    }

    private void GetHighScore()
    {
        highScoreObject.text = $"High Score: {PlayerState.Instance.HighScore} - {PlayerState.Instance.PlayerName}";
    }

    public void StartGame()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);
    }
}

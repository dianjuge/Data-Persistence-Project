using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    public Text playerName;
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        ShowBestPlayerScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowBestPlayerScore()
    {
        score.text = $"Best Score : {DataTransit.instance.bestPlayerName} : {DataTransit.instance.playerScore}";
    }
    public void GetPlayerName()
    {
        
        DataTransit.instance.playerName = playerName.text;    
    }

    public void GameStart()
    {
        GetPlayerName();
        DataTransit.instance.SaveName();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

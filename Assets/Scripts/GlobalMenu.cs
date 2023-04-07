using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalMenu : MonoBehaviour
{
    public static GlobalMenu Instance;
    public GameObject MenuButton;
    public GameObject QuitButton;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance is not null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void HideButtons()
    {
        MenuButton.SetActive(false);
    }

    public void ShowButtons()
    {
        MenuButton.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        HideButtons();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        PlayerState.Instance.SaveCurrentData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

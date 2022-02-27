using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainmenuPanel;
    [SerializeField]
    private GameObject instructionPanel;
    [SerializeField]
    private GameObject creditPanel;

    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        mainmenuPanel.SetActive(true);
        instructionPanel.SetActive(false);
        creditPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnCreditButtonClicked()
    {
        mainmenuPanel.SetActive(false);
        creditPanel.SetActive(true);
    }

    public void OnBackButtonClicked()
    {
        mainmenuPanel.SetActive(true);
        creditPanel.SetActive(false);
        instructionPanel.SetActive(false);
    }

    public void OnInstructionButtonClicked()
    {
        mainmenuPanel.SetActive(false);
        creditPanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void OnQuitButtonClicked()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    
    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}

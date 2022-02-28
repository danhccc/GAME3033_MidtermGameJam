using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameoverScreen : MonoBehaviour
{
    public GameObject gameoverPanel;

    public TextMeshProUGUI timeSpent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0.0f;
            gameoverPanel.SetActive(true);
            timeSpent.text = "???";
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("Level1");
    }

}

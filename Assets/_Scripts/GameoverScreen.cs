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

    public PlayerController player;

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
            Gameover();
        }
    }

    public void restartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }

    public void Gameover()
    {
        Time.timeScale = 0.0f;
        gameoverPanel.SetActive(true);
        timeSpent.text = player.timer.ToString("F2");
        Cursor.visible = true;
    }
}

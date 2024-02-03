using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverUI : MonoBehaviour
{

    public GameObject gameOverPanel;
    [SerializeField]
    private Text GameOverText;
    [SerializeField]
    private Text RestartText;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }
    private void Update()
    {
        if (ManagerContainer.Instance.Game.GameEnded == true)
        {
            
            ActivateGameOverPanel();
        }
    }
    public void ActivateGameOverPanel()
    {
        gameOverPanel.SetActive(true);

    }


    public void Build()
    {

    }

}

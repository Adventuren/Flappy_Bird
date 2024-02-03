using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerContainer : MonoBehaviour
{

    #region Singleton

    public static ManagerContainer Instance { get; private set; }

    #endregion

    #region Managers

    
    public GameOverUI GameEndUI { get; private set; }
    public ScoreManager Score { get; private set; }
    [SerializeField]
    private ScoreUI _scoreUI;
    [SerializeField]
    private GameManager _game;
    public GameManager Game { get; private set; }
    public SpawnManager Spawn { get; private set; }
    public GameSpeedManager Speed { get; private set; }
    public InputManager Input { get; private set; }
    [SerializeField]
    private InputManager _input;
    [SerializeField]
    private SpawnManager _spawn;
    [SerializeField]
    private PlayerController Player;
    #endregion

   
    [SerializeField]
    private Transform _spawnPos1;
    public Transform SpawnPos1 { get; set; }
    [SerializeField]
    private Transform _spawnPos2;
    public Transform SpawnPos2 { get; set; }
    [SerializeField]
    private float _gameSpeed;
    public float GameSpeed { get; set; }

    private void Awake()
    {
        Instance = this;

        Init();
    }

    public void Init()
    {

        

        SpawnPos2 = _spawnPos2;

        GameSpeed = _gameSpeed;

        SpawnPos1 = _spawnPos1;

        CreateManagers();

        BuildManagers();

        Player.AddEvent();
    }

    private void CreateManagers()
    {
       

        GameEndUI = new GameOverUI();

        Score = new ScoreManager();

        Game = _game;

        Spawn = _spawn;

        Speed = new GameSpeedManager();

        Input = _input;

        Score.ScoreUI = _scoreUI;

    }

    private void BuildManagers()
    {
        Spawn.Build();

        Speed.Build();

        Input.Build();

        Game.Build();

        Score.Build();

        GameEndUI.Build();

      
        

    }



}

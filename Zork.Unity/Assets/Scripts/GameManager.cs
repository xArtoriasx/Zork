﻿using Zork;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI CurrentLocationText;

    [SerializeField]
    private TextMeshProUGUI MovesText;

    [SerializeField]
    private TextMeshProUGUI ScoreText;

    [SerializeField]
    private UnityInputService InputService;

    [SerializeField]
    private UnityOutputService OutputService;

    void Start()
    {
        TextAsset gametextAsset = Resources.Load<TextAsset>("Zork");
        _game = JsonConvert.DeserializeObject<Game>(gametextAsset.text);
        _game.Player.LocationChanged += (sender, Location) => CurrentLocationText.text = Location.ToString();
        _game.Start(InputService, OutputService);
        _game.Player.MovesChanged += (sender, moves) => MovesText.text = moves.ToString();
        _game.Player.ScoreChanged += (sender, score) => ScoreText.text = score.ToString();
    }

    private Game _game;
}

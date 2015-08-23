﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int Gold = 0;
    public int Food = 0;
    public int Gems = 0;
    public int Evil = 0;
    public int Desire = 0;

    public int GoldPerDrop = 10;
    public int GemsPerDrop = 5;

    public GameObject GoldMinePrefab;
    public GameObject GemMinePrefab;
    public GameObject GameUIPrefab;
    public GameObject GemMineBuilder;
    public BuildQueueManager QueueManager;

    public static GameManager Instance;

    public enum RoomType
    {
        GoldMine,
        GemMine
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        RoomManager.Instance.NewLevel();
        QueueManager = Instantiate(GameUIPrefab).GetComponent<BuildQueueManager>();
    }

    public void DropGold()
    {
        Gold += GoldPerDrop;
    }

    public void DropGems()
    {
        Gems += GemsPerDrop;
    }

    public void BuyRoom(RoomType room)
    {
        switch (room)
        {
            case RoomType.GoldMine:
                RoomManager.Instance.AddRoom(Instantiate(GoldMinePrefab));
                break;
            case RoomType.GemMine:
                QueueManager.Enqueue(GemMineBuilder);
                //RoomManager.Instance.AddRoom(Instantiate(GemMinePrefab));
                break;
        }
    }

}

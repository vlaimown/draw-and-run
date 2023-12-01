using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform finish;
    void Start()
    {
        
    }

    void Update()
    {
        player.Move(finish);
    }
}

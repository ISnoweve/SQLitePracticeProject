using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    CharacterInformation _characterInformation;
    CharacterInformation _characterInformation2;
    
    HealthInformation _healthInformation;
    HealthInformation _healthInformation2;

    private void Awake()
    {
        _characterInformation = new CharacterInformation
        {
            Username = "Player",
            Lv = 1,
            Exp = 0,
            Hp = 100,
            Mp = 100
        };
    }
    private void Start()
    {
        DataService.Instance.CreateTable<CharacterInformation>();
    }
}

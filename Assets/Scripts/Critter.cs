﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Critter : MonoBehaviour
{
    [Header("Name")]
    [SerializeField]
    private string critterName;

    [Header("Base Stats")]
    [SerializeField]
    [Range(10,100)]
    private int baseAtk;
    [SerializeField]
    [Range(10, 100)]
    private int baseDef;
    [SerializeField]
    [Range(1, 50)]
    private int baseSpd;
    [SerializeField]
    private float baseHp;

    [Header("Affinity")]
    [SerializeField]
    private Affinity affinity;


    [Header("Skill Set")]
    //[SerializeField]
    //private SkillSet skills;
    [SerializeField]
    private Skill skill1;
    [SerializeField]
    private Skill skill2;
    [SerializeField]
    private Skill skill3;

    



    // Start is called before the first frame update
    void Start()
    {
        print(critterName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum Affinity
{
    Fire,
    Wind,
    Water,
    Earth,
    Dark,
    Light
}
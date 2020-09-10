using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critter : MonoBehaviour
{
    [SerializeField]
    private string critterName;

    [Header("Base Stats")]
    [SerializeField]
    private float baseAtk, 
        baseDef, 
        baseSpd, 
        baseHp;

    [Header("Afinity")]
    [SerializeField]
    private Affinity affinity;

    [Header("Skill Set")]
    [SerializeField]
    private Skill skill1, skill2, skill3;

    



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
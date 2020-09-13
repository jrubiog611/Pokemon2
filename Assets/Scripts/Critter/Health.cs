using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private Critter critter;
    private Affinity critterAf;
    public float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        critter = transform.GetComponent<Critter>();
        critterAf = critter.Affinity;
        currentHealth = critter.BaseHp;
    }
    public void TakeDamage(float amout, Affinity atkType)
    {
        currentHealth -= amout * AffinityMultiplier.Multiplier(critterAf, atkType);
        if (currentHealth <= 0)
        {
            ImDead();
        }
    }

    private void ImDead()
    {
        critter.Owner.RemoveCritter(critter);
    }
}

public class AffinityMultiplier
{
    public static float Multiplier(Affinity ownType, Affinity atkType)
    {
        float[,] affinityTable = new float[,]
        {
            {0.5f,2,1,1,1,1 },
            {2,0.5f,1,1,1,1 },
            {1,1,0.5f,0.5f,1,1 },
            {1,1,2,0.5f,0.5f,1 },
            {1,1,1,2,0.5f,2 },
            {1,1,0,1,0.5f,0.5f }
        };

        return affinityTable[(int)ownType,(int)atkType];
    }
}

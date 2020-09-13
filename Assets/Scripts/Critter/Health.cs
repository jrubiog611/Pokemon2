using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private Critter critter;
    private Affinity critterAf;
    public float currentHealth;
    private SpriteRenderer critterSprite;
    [SerializeField]
    private RectTransform healtBar;
    private Vector2 initialHealBarSize;


    // Start is called before the first frame update
    void Start()
    {
        initialHealBarSize = healtBar.sizeDelta;
        critter = GetComponent<Critter>();
        critterAf = critter.Affinity;
        currentHealth = critter.BaseHp;
        critterSprite = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float amount, Affinity atkType)
    {
        StartCoroutine(DamageEffect(amount,atkType));
    }

    private void ImDead()
    {
        critter.Owner.RemoveCritter(critter);
    }

    private IEnumerator DamageEffect(float amount, Affinity atkType)
    {
        float time, dmgTime;
        time = 0;
        dmgTime = 0.5f;
        critterSprite.color = Color.red;
        Vector3 spritePos = transform.position;
        while (time <= dmgTime)
        {
            time += Time.deltaTime;
            transform.position += new Vector3( Random.Range(-0.1f,0.1f), Random.Range(-0.1f, 0.1f), 0);
            yield return new WaitForEndOfFrame();
        }
        transform.position = spritePos;
        critterSprite.color = Color.white;
        currentHealth -= amount * AffinityMultiplier.Multiplier(critterAf, atkType);
        healtBar.sizeDelta = new Vector2(currentHealth*initialHealBarSize.x/critter.BaseHp, initialHealBarSize.y);
        if (currentHealth <= 0)
        {
            ImDead();
        }
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

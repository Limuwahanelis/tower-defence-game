using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyStats : ScriptableObject
{
    public int maxHealth;
    public float movementspeed;
    public int dmgToNexus;
}

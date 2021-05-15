using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Towers/Simple Tower")]
public class TowerStats : ScriptableObject
{
    public float attackRange;
    public float attackDamage;
    public float attackRate;
    public float missileSpeed;
}

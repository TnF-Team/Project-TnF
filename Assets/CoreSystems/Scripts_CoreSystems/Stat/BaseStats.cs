using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseStats : MonoBehaviour
{
    public enum NowState
    {
        Idle,
        Move,
        Run,
        Crouchi,
        Jump,
        Attack,
        Skill,
        Death
    }

    [Header("BaseStats - PlayerStats, EnemyStats")]
    public float max_Hp;
    public float cur_Hp;
    public int def;

    public int MagazineCapacity;//장탄 수 25/200 중에 25
    public int AmmoMax;//탄약 최대량 25/200 중에 200
    public float reloadingSpd;
    public float moveSpd;

    public float dmg;
    public float fatalDmg;// 헤드샷 = 100%치명뎀

    public float atkRange;
    public float fatalPercent;

    public bool able_UltimitSkill = false;
    public bool able_BasicSkill = false;
    public bool isMelee = false;
    public bool isArea_Atk = false;

    [Header("Entity_Action")]
    public NowState nowState;
    public bool isAttack = false;
    public bool isAtkDone = false;
    public bool isDie = false;

    
}

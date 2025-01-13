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

    public int MagazineCapacity;//��ź �� 25/200 �߿� 25
    public int AmmoMax;//ź�� �ִ뷮 25/200 �߿� 200
    public float reloadingSpd;
    public float moveSpd;

    public float dmg;
    public float fatalDmg;// ��弦 = 100%ġ��

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

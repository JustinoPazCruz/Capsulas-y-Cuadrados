using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public float speed;
    public float range;
    public float maxdistance;

    public Transform Player;

    public GameObject enemigo1;

    private Vector2 WayPoint;

    public enum ENEMY_STATE
    { 
        Wander,
        Attack,
        Nothing,
    }

    public ENEMY_STATE enemystate;

    void Start()
    {
        SetNewDestination();
    }

    
    void Update()
    {
        switch(enemystate)
        {
            case ENEMY_STATE.Wander:
                transform.position = Vector2.MoveTowards(transform.position, WayPoint, speed * Time.deltaTime);
                if(Vector2.Distance(transform.position, WayPoint) > range)
                {
                    SetNewDestination();
                }
                if(Input.GetKey(KeyCode.J))
                {
                    enemystate = ENEMY_STATE.Attack;
                }
                if(Input.GetKey(KeyCode.K))
                {
                    enemystate = ENEMY_STATE.Nothing;
                }
                break;

            case ENEMY_STATE.Attack:
                transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
                if (Input.GetKey(KeyCode.H))
                {
                    enemystate = ENEMY_STATE.Wander;
                }
                if (Input.GetKey(KeyCode.K))
                {
                    enemystate = ENEMY_STATE.Nothing;
                }
                break;

            case ENEMY_STATE.Nothing:
                Debug.Log("Doing Nothing for now");
                break;
        }
    }

    void SetNewDestination()
    {
        WayPoint = new Vector2(Random.Range(-maxdistance, maxdistance), Random.Range(-maxdistance, maxdistance));
    }
}

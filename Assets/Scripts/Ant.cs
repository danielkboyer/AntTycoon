using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour, IAnt
{
    public float TurnRadius = 50f;
    public float DecisionRate = 1f;
    public float Speed = 1;
    public float RotSpeed = 1f;
    private float currentDecisionRateTime = 0f;
    private float direction = 0f;
    private float turnAmount = 0f;
    private float totalTurn = 0f;

    public IMap Map;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveRandom();
        
    }


    void MoveRandom()
    {
        currentDecisionRateTime += Time.deltaTime;

        if(currentDecisionRateTime > DecisionRate)
        {
            direction = Random.Range(-TurnRadius, TurnRadius);
            turnAmount = direction / DecisionRate;
            currentDecisionRateTime = 0;
        }
        totalTurn += turnAmount * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(totalTurn, Vector3.up);

        var newPos = transform.position + transform.forward * Speed * Time.deltaTime;
        

        if (Map.GetObj(Map.GetTransform().InverseTransformPoint(newPos).x, Map.GetTransform().transform.InverseTransformPoint(newPos).z).isPath)
        {
            transform.position = newPos;
        }
    }

    public void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    AntType IAnt.GetType()
    {
        throw new System.NotImplementedException();
    }

    public void Attack(IAnt toAttack)
    {
        throw new System.NotImplementedException();
    }

    public Vector3 GetPos()
    {
        throw new System.NotImplementedException();
    }
}

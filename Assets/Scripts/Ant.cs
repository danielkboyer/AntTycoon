using Assets.Scripts;
using Assets.Scripts.BlockInfos;
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
    private Block _currentBlock;
    public NavigationStatus NavStatus;
    public AntStatus Status;
    public IMap Map;
    public GameObject Hive_F;
    public float Hive_F_Expiry;
    public int SightDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NavStatus == NavigationStatus.NAVIGATING)
            MoveRandom();
        else if (NavStatus == NavigationStatus.RETURNING)
            FoodNav();
        
    }

    List<Sense> GetSenses()
    {
        return null;
    }
    void FoodNav()
    {

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


        Vector3 mapCoords = Map.GetTransform().InverseTransformPoint(newPos);
        Block futureBlock = Map.GetBlock(mapCoords.x, mapCoords.z);
        if (futureBlock.IsPathway)
        {
            if (_currentBlock == null || _currentBlock != futureBlock)
            {
                _currentBlock = futureBlock;
                Destroy(Instantiate(Hive_F, transform.position, Quaternion.identity), Hive_F_Expiry);

                Map.AddBlockInfo(mapCoords.x, mapCoords.z, new Hive_F(Hive_F_Expiry));
                Map.AddBlockInfo(mapCoords.x, mapCoords.z, new AntB(this));
            }
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

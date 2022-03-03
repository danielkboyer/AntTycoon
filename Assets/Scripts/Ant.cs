using Assets.Scripts;
using Assets.Scripts.BlockInfos;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public IMap Map;
    public float Lay_F_Time;
    private float _currentLayFTime;
    public float Hive_F_Expiry;
    public float Food_F_Expiry;
    public int SightDistance;
    public float SightStep;


    public Food CurrentFood;
    private List<Vector3> sightPositions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        NavStatus = NavigationStatus.NAVIGATING;
        Map = FindObjectOfType<Map>();
        _currentLayFTime = Lay_F_Time;
    }

    // Update is called once per frame
    void Update()
    {
        //sightPositions.Clear();
        _currentLayFTime -= Time.deltaTime;

        Move();
      
        
    }


    public PriorityQueue<Sense> GetSenses()
    {
        var curPos = Map.GetTransform().InverseTransformPoint(transform.position);
        Block currentBlock = Map.GetBlock(curPos.x,curPos.z);
        PriorityQueue <Sense> senses = new PriorityQueue<Sense>();
        //Forward
        AddDirectionSense(senses, transform.forward.normalized, new Vector2(transform.position.x, transform.position.z), 0, currentBlock);
        //Right
        AddDirectionSense(senses, transform.right.normalized, new Vector2(transform.position.x, transform.position.z), 90, currentBlock);
        //Left
        AddDirectionSense(senses, (-transform.right).normalized, new Vector2(transform.position.x, transform.position.z), -90, currentBlock);
        //BackWard
        //AddDirectionSense(senses, (-transform.forward).normalized, new Vector2(transform.position.x, transform.position.z), 180);
        AddDirectionSense(senses, (transform.right + transform.forward).normalized, new Vector2(transform.position.x, transform.position.z), transform.rotation.y + 45, currentBlock);
        AddDirectionSense(senses, ((-transform.right) + transform.forward).normalized, new Vector2(transform.position.x, transform.position.z), transform.rotation.y - 45, currentBlock);
        return senses;

    }
    //TODO
    public PriorityQueue<Sense> AddDirectionSense(PriorityQueue<Sense> senses,Vector3 normalizedDirection, Vector2 position, float direction, Block currentBlock)
    {
        float xAdd = normalizedDirection.x * SightStep;
        float zAdd = normalizedDirection.z * SightStep;


        float x = SightStep;
        position.x += xAdd;
        position.y += zAdd;

        while(x < SightDistance)
        {
            
            var mapPos = Map.GetTransform().InverseTransformPoint(new Vector3(position.x, transform.position.y, position.y));
            var sense = new Sense(NavStatus, x, Map.GetBlock(mapPos.x, mapPos.z), direction);
            if(sense.Block != currentBlock)
                senses.Enqueue(sense);
            if (!sense.Block.IsPathway)
            {
                break;
            }
            
            //sightPositions.Add(new Vector3(position.x, 0, position.y));
            position.x += xAdd;
            position.y += zAdd;
            x += SightStep;

        }
        return senses;
    }
   
    public void Move()
    {
        currentDecisionRateTime += Time.deltaTime;

        if(currentDecisionRateTime > DecisionRate)
        {
            var senses = GetSenses();
            var topPriority = senses.Dequeue();
            //Debug.Log($"Navigation Priority: {topPriority.Block.GetNavigationScore(topPriority.Distance)}");
            direction = topPriority.Angle;
            turnAmount = direction / DecisionRate;
            
            currentDecisionRateTime = 0;
        }
        totalTurn = turnAmount * Time.deltaTime;

        transform.RotateAround(transform.position, transform.up, totalTurn);
        var newPos = transform.position + transform.forward * Speed * Time.deltaTime;


        Vector3 mapCoords = Map.GetTransform().InverseTransformPoint(newPos);
        Block futureBlock = Map.GetBlock(mapCoords.x, mapCoords.z);
        if (futureBlock.IsPathway)
        {
            if (_currentBlock == null || _currentBlock != futureBlock)
            {
                _currentBlock = futureBlock;
                if (NavStatus == NavigationStatus.NAVIGATING)
                {
                    if(_currentLayFTime > 0)
                        Map.AddBlockInfo(mapCoords.x, mapCoords.z, new Hive_F(this.transform.position, Hive_F_Expiry, Map.GetTransform()));
                    if (Map.HasFood(mapCoords.x, mapCoords.z) && CurrentFood == null)
                    {
                        _currentLayFTime = Lay_F_Time;
                        CurrentFood = Map.GetFood(mapCoords.x, mapCoords.z);
                        NavStatus = NavigationStatus.RETURNING;

                    }
                    else if (Map.IsHive(mapCoords.x, mapCoords.z))
                    {
                        _currentLayFTime = Lay_F_Time;
                        
                    }
                }
                else if(NavStatus == NavigationStatus.RETURNING)
                {
                    if(_currentLayFTime > 0)
                        Map.AddBlockInfo(mapCoords.x, mapCoords.z, new Food_F(this.transform.position, Food_F_Expiry, Map.GetTransform()));
                    if (Map.IsHive(mapCoords.x,mapCoords.z))
                    {
                        _currentLayFTime = Lay_F_Time;
                        CurrentFood.AtHive = true;
                        Map.AddBlockInfo(mapCoords.x, mapCoords.z, CurrentFood);
                        CurrentFood = null;
                        NavStatus = NavigationStatus.NAVIGATING;

                    }
                    

                }
                

                Map.AddBlockInfo(mapCoords.x, mapCoords.z, new AntB(this));

            }
            transform.position = newPos;
        }
        else
        {
            transform.RotateAround(transform.position, transform.up,TurnRadius*Time.deltaTime);
        }

        if(NavStatus == NavigationStatus.RETURNING && CurrentFood != null)
        {
            CurrentFood.Position = transform.position + new Vector3(0,.05f,0);
            CurrentFood.UnityObject.transform.position = transform.position + new Vector3(0, .05f, 0);
        }
    }

    public void TakeDamage(int amount)
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

    private void OnDrawGizmos()
    {
        foreach (var position in sightPositions)
        {
            Gizmos.DrawSphere(new Vector3(position.x, position.y, position.z), .01f);
        }
    }
    
}

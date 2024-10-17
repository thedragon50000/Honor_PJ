using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SearchEnemy : MonoBehaviour
{
    public float moveSpeed; //移動速度
    public float EyeViewDistance; //視野距離
    public float viewAngle = 120f; //視野角度

    private Rigidbody rb;
    private Collider[] SpottedEnemies; //附近的敵人
    public Collider eyeCollider;
    public Collider listenCollider;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        DetectEnemy();
    }

    void Update()
    {
        // AutoMove();
        MoveAndTurn();
        Debug.DrawLine(transform.position, transform.forward * EyeViewDistance, Color.red); //红色射線面對方向
    }


    void AutoMove() //向面對的方向自動移動
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void MoveAndTurn() //玩家移動
    {
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hitInfo = new RaycastHit();
        // //shoot a ray from cam to mouse position which is only detected by gameobject with "Plane" layer.
        // Physics.Raycast(ray, out hitInfo, 100);
        // if (hitInfo.collider.name == "Plane")
        // {
        //     transform.LookAt(new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z));
        // }

        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
    }

    void DetectEnemy() //探測敵人
    {
        //OverlapSphere内的敵人
        SpottedEnemies = Physics.OverlapSphere(transform.position, EyeViewDistance /*, 1 << LayerMask.GetMask("Default")*/);
        for (int i = 0; i < SpottedEnemies.Length; i++) //檢測每一個敵人是否在視野區中
        {
            if (!SpottedEnemies[i].CompareTag("Player"))
            {
                continue;
            }

            Vector3 EnemyPosition = SpottedEnemies[i].transform.position; //敵人的位置

            //Debug.Log(transform.forward + " 面對的方向");
            //Debug.Log("夾角為:" + Vector3.Angle(transform.forward, EnemyPosition - transform.position));

            Debug.DrawRay(transform.position, EnemyPosition - transform.position, Color.green); //玩家位置到敵人位置的向量
            if (Vector3.Angle(transform.forward, EnemyPosition - transform.position) <= viewAngle / 2) //敵人是否在視野内
            {
                //如果在視野内
                RaycastHit info = new RaycastHit();
                Physics.Raycast(transform.position, EnemyPosition - transform.position, out info, EyeViewDistance /*,
                    layermask*/); //向敵人發射射線
                // Debug.Log(info.collider.gameObject.name);
                if (info.collider == SpottedEnemies[i]) //如果途中無其他障礙物，那麼射線就會碰撞敵人
                {
                    DiscoveredEnemy(SpottedEnemies[i]);
                }
            }
        }
    }

    void DiscoveredEnemy(Collider Enemy) //發現敵人
    {
        //Do something
        Debug.Log("發現敵人:" + Enemy.gameObject.name);
        Enemy.GetComponent<Player>().BeDiscovered();
    }
}
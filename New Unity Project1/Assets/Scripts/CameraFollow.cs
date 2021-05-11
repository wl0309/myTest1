using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTran;//代表主角的transform
    public float MaxDistanceX = 2;
    public float MaxDistanceY = 2;
    public float xSpeed = 4;
    public float ySpeed = 4;
    public Vector2 maxXandY;
    public Vector2 minXandY = new Vector2(-8, 8);
     //Start is called before the first frame update
    private bool NeedMoveX()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.x - playerTran.position.x) > MaxDistanceX)
            bMove = true;
        else
            bMove = false;
        return bMove;
        //return Mathf.Abs(transform.position.x - playerTran.position.x) > MaxDistanceX;
    }
    private bool NeedMoveY()
    {
        bool bMove = false;
        if (Mathf.Abs(transform.position.y - playerTran.position.y) > MaxDistanceY)
            bMove = true;
        else
            bMove = false;
        return bMove;
        //return Mathf.Abs(transform.position.y - playerTran.position.y) > MaxDistanceY;
    }
    void Start()
    {
        
    }
    private void Awake()//运行在start之前
    {
        //playerTran = GameObject.Find("Hero").transform;//第一种方式将摄像机找到主角
        playerTran = GameObject.FindGameObjectWithTag("Player").transform;//第二种方式，通过寻找标签来实现
        // Update is called once per frame
    }
    void Update()
    {
        TrackPlayer();
    }
    private void TrackPlayer()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        if (NeedMoveX()) 
            newX = Mathf.Lerp(transform.position.x, playerTran.position.x, xSpeed * Time.deltaTime);
        if (NeedMoveY())
            newY = Mathf.Lerp(transform.position.y, playerTran.position.y, ySpeed * Time.deltaTime);
        //newX = Mathf.Clamp(newX, minXandY, maxXandY);

        transform.position = new Vector3(newX,newY, transform.position.z);
    }
    private void FixedUpdate()
    {
        ///TrackPlayer();
    }
}

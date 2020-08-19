using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridMovement : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public Transform movePosition;
    public int maxGridMoveDistance;
    int moves;
    bool moveH,moveV;

    private void Start() 
    {
        moves = maxGridMoveDistance;        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        //direction = new Vector2(h,v).normalized;

        transform.position = Vector2.MoveTowards(transform.position,movePosition.position,speed*Time.deltaTime);
        
        if(h != 0)
        {
            moveH = true;
            moveV = false;
        }else if(v != 0)
        {
            moveV = true;
            moveH = false;
        }else
        {
            moveH = false;
            moveV = false;
            moves = maxGridMoveDistance;
        }

        if(moveH && moves > 0)
        {
            if(h > 0)
            {
                movePosition.position = new Vector2(movePosition.position.x + 1,movePosition.position.y);
            }else if(h < 0)
            {
                movePosition.position = new Vector2(movePosition.position.x - 1,movePosition.position.y);
            }
            moves--;
        }
        
        if(moveV && moves > 0)
        {
            if(v > 0)
            {
                movePosition.position = new Vector2(movePosition.position.x ,movePosition.position.y + 1);
            }else if(v < 0)
            {
                movePosition.position = new Vector2(movePosition.position.x ,movePosition.position.y - 1);
            }
            moves--;
        }
    }
}

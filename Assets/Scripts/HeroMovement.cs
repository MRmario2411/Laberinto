using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up,down,left,right
}
public class HeroMovement : MonoBehaviour
{
    //Animator anim;
    Vector2 targetPosition;
    Direction direction;
    public LayerMask limiter;
    public GameObject player; 

    public int speed = 5;

    void Start()
    {
        //anim = GetComponent<Animator>();
        targetPosition = transform.position;
        direction = Direction.down;
    }
    
    void Update (){
        Vector2 axisDirection = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        //anim.SetInteger("direction", (int)direction);
        if(axisDirection != Vector2.zero && targetPosition == (Vector2)transform.position){
            if  (Mathf.Abs(axisDirection.x) > Mathf.Abs(axisDirection.y)){
                if(axisDirection.x > 0){
                    direction = Direction.right;
                    //player.GetComponent<SpriteRenderer>().flipX = false;
                    if(!checkCollision)
                        targetPosition += Vector2.right;
                }else{
                    direction = Direction.left;
                    //player.GetComponent<SpriteRenderer>().flipX = true;
                    if(!checkCollision)
                        targetPosition -= Vector2.right;
                }
            }else{
                if(axisDirection.y > 0){
                    direction = Direction.up;
                    if(!checkCollision)
                        targetPosition += Vector2.up;
                }else{
                    direction = Direction.down;
                    if(!checkCollision)
                        targetPosition -= Vector2.up;
                }

            }
        }
        transform.position = Vector2.MoveTowards(transform.position,targetPosition,speed * Time.deltaTime); //MoveTowards is a function that moves the object towards a target position



    }

    bool checkCollision
    {
        get
        {
            RaycastHit2D rh;

            Vector2 dir = Vector2.zero;

            if(direction == Direction.down){
                dir = Vector2.down;
            }else if(direction == Direction.up){
                dir = Vector2.up;
            }else if(direction == Direction.left){
                dir = Vector2.left;
            }else{
                dir = Vector2.right;
            }


            rh = Physics2D.Raycast(transform.position, dir,1, limiter);
            Debug.Log("El colider es"+rh.collider);
            return rh.collider != null;
        }
    }

}

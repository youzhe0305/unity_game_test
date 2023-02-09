using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float XForce = 5;
    public float JumpForece = 10;
    public float XSpeedConstrait = 0.1f;

    public float YSpeedConstrait = 0.1f;

    public GameObject bullet;

    public Animator player_ani;
    public SpriteRenderer player_sprite;
    Rigidbody2D body;
    int JumpTime = 0;
    int JumpConstrait = 1;
    bool is_walking = false;
    bool is_jump = false;

    
    void Start()
    {
        Debug.Log("move start");
        body = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {  
        
        if(is_jump==true) player_ani.SetInteger("status",2);
        else if(is_walking==true) player_ani.SetInteger("status",1);
        else player_ani.SetInteger("status",0);
        if(Input.GetKeyDown(KeyCode.J)){
            Instantiate(bullet,this.gameObject.transform.position,Quaternion.identity);       
        }
        if(Input.GetKey(KeyCode.D)){
            body.AddForce(new Vector2(XForce,0),ForceMode2D.Impulse);
        }
        if(Input.GetKey(KeyCode.D)){
            if(player_sprite.flipX==true) player_sprite.flipX = false;
            is_walking = true;
        }
        if(Input.GetKeyUp(KeyCode.D)){
            is_walking = false;
        }
        if(Input.GetKey(KeyCode.A)){
            if(player_sprite.flipX==false) player_sprite.flipX = true;
            is_walking = true;
        }
        if(Input.GetKeyUp(KeyCode.A)){
            is_walking = false;
        }
        if(Input.GetKey(KeyCode.A)){
            body.AddForce(new Vector2(-XForce,0),ForceMode2D.Impulse);     
        }       
        if(body.velocity.x >= XSpeedConstrait){
            body.velocity = new Vector2(XSpeedConstrait,body.velocity.y);
        }
        if(body.velocity.x <= -XSpeedConstrait){
            body.velocity = new Vector2(-XSpeedConstrait,body.velocity.y);
        }
        if(JumpTime < JumpConstrait){
            if(Input.GetKeyDown(KeyCode.Space)){
                is_jump = true;
            }
            if(Input.GetKey(KeyCode.Space)) {
                body.AddForce(new Vector2(0,JumpForece),ForceMode2D.Impulse);
                JumpTime += 1;
            }
        }
    }

private void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.tag=="plate"){
        print("yoyo");
        JumpTime = 0;
        is_jump = false;
    }
}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetpack : MonoBehaviour
{

    
    public float jetpackforce = 50f;
    private Rigidbody2D rb;
    Movement movementScript;
    public Movement playerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    
        


        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown("j"))
        {
            if( playerScript.isGrounded == false )
            {
                playerGameobject.rb.AddForce(new Vector2(0, jetpackforce));
                print("j pressed");
            }
        }
        



    }
}

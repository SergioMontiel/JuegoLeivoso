using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    float runSpeed = 10f;
    float jumpSpeed = 10f;
    Animator myAnimator;
    CapsuleCollider2D mybodyCollider;
    BoxCollider2D myfeetCollider;

    //Función muy utilizada en el desarrollo de juegos!!!
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        //Esta es la funcion
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mybodyCollider = GetComponent<CapsuleCollider2D>();
        myfeetCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    //Para usar otro tipo de actualizacion para los controles se puede usar Fixed Update (evitara que te traicione y no sobreescribira sobre la informacion)
    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        
    }

    void Run()
    {
        //Obtener el float del control que va de -1 a 1
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        //Inicializar un vector de dos dimensiones que solo modifica el componente x
        Vector2 playerVelocity = new Vector2(controlThrow*runSpeed, myRigidBody.velocity.y);

        //Asignar la nueva velocidad a mi rigid body
        myRigidBody.velocity = playerVelocity;

        //Aplicar animación de correr setenado la condición de "running" del animator
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > 0;
        if (playerHasHorizontalSpeed)
        {
            myAnimator.SetBool("Running", true);
        }
        else
        {
            myAnimator.SetBool("Running", false);
        }
        
    }

    void FlipSprite()
    {
        /*Verificar si existe velocidad en x independientemente del signo (por eso usamos valor absoluto)
         Guardamos esta verificacion como un valor booleano (true/false)
         */
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > 0;
        //Preguntamos si la condicion es verdadera
        if (playerHasHorizontalSpeed)
        {
            //Si sí es verdadera, toma el signo de la velocidad en x y altera la escala en esa dimension
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    void Jump()
    {
        if (!myfeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        //Obtener el booleano del boton representado por el tag  "Jump"
        bool isJumpButtonPressed = CrossPlatformInputManager.GetButtonDown("Jump");
        if (isJumpButtonPressed)
        {
            Vector2 jumpVelocity = new Vector2(0, jumpSpeed);

            //Sumarle a la velocidad que ya tiene mi nuevo vector de velocidad
            //myRigidBody.velocity = myRigidBody.velocity += jumpVelocity
            myRigidBody.velocity += jumpVelocity;
        }
        
    }
}

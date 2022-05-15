using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enum que uso pra StateMachine
//Pode ser substituida por uma int
public enum PlayerState
{
    //Caso fosse uma int pra state machine cada um representaria um numero
    moving, //Mesma coisa que 0
    inPuzzle, //Mesma coisa que 1
    inDialogue //Mesma coisa que 2
}
public class Player : MonoBehaviour
{
    public static Player instance;
    //Ponho isso pra ter referencia de qual o estado atual
    [SerializeField] PlayerState state = PlayerState.moving;
    #region Não é state
    [SerializeField] CharacterController controller;
    public float speed = 12f;
    private Vector3 velocity;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundmask;
    [SerializeField] float JumpHeight = 3.0f;
    private bool noChão;
    public Camera cam;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    public bool canPause;
    #endregion

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //redundancia pra afirmar esse estado quando começa uma cena
        state = PlayerState.moving;
    }

    void Update()
    {
        //State machine pra ver quais metodos podem ser chamados durante o update
        //em relação ao estado do player
        switch (state)
        {
            case PlayerState.moving:
                PlayerMovement();
                break;
            case PlayerState.inPuzzle:
                break;
            case PlayerState.inDialogue:
                break;
        }
    }
    public void SetState(PlayerState state)
    {
        //Responsavel por trocar e atualizar o estado do player
        //Como o player tem "instance" esse metodo pode ser chamado
        //por qualquer outro script do jogo pra definir qual o estado que o player esta

        //Chamada generia Script.instance.Funcão_que_muda_estado(Enum.Estado_que_quero)
        //Ex de chamada: Player.instance.SetState(Playerstate.moving)

        switch (state)
        {
            case PlayerState.moving:
                GameManager.instance.LockCursor();
                canPause = true;
                break;
            case PlayerState.inPuzzle:
                GameManager.instance.UnlockCursor();
                canPause = false;
                break;
            case PlayerState.inDialogue:
                GameManager.instance.UnlockCursor();
                canPause = false;
                break;
        }
        this.state = state;
    }
    public void PlayerMovement()
    {
        #region Movimento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right *x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
        #endregion
        #region Movimento Horizontal
        noChão = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);
        velocity.y += gravity * Time.deltaTime;
        if(noChão && velocity.y < 0 )
        {
            velocity.y = -2f;
        }
        if(Input.GetButtonDown("Jump") && noChão)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
        #endregion
        #region Movimento da câmera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 
        transform.Rotate(Vector3.up * mouseX);
        #endregion
    }
}

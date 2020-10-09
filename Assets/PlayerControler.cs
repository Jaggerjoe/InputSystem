using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset m_PlyerControl;

    [SerializeField]
    private float m_speed = 6f;

    //private InputActionMap m_PlayerMap;
    //private InputAction m_ActionMap;
    
    private Vector2 m_MovementInput = Vector2.zero;

    private void Awake()
    {
        InputActionMap playerMap = m_PlyerControl.FindActionMap("Player");

        InputAction shootAction = m_PlyerControl.FindAction("Shoot");
        shootAction.performed += (ctx) => { Shoot(); };

        InputAction moveAction = m_PlyerControl.FindAction("Move");
        moveAction.performed += (ctx) => { m_MovementInput = ctx.ReadValue<Vector2>(); };
        moveAction.canceled += (ctx) => { m_MovementInput = Vector2.zero; };

        playerMap.Enable();
    }
    private void Update()
    {
        Move(m_MovementInput, Time.deltaTime);
    }
    public void Move(Vector2 _Direction, float _deltaTime)
    {
        _Direction.Normalize();
        Vector3 movement = new Vector3(_Direction.x, 0f, _Direction.y);
        transform.position += movement * m_speed * _deltaTime;

        //Debug.DrawRay(transform.position, _Direction, Color.yellow, .2f);
        //Debug.Log("Move " + _Direction);
        
    }

    public void Shoot()
    {
        Debug.Log("T'es mauvais jack");
    }
}

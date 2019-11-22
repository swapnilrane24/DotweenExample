using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private float speed = 6.0f, jumpSpeed = 8f, gravity = 20f;

    private CharacterController _characterController;
    private bool _lookingRight = true;
    Vector3 _moveDirection, spawnPos;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        spawnPos = transform.position;
    }

    private void Update()
    {
        if (_characterController.isGrounded)
        {
            _moveDirection = Vector3.right * Input.GetAxis("Horizontal");
            _moveDirection *= speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _moveDirection.y = jumpSpeed;
            }
        }

        if (_moveDirection.x < 0 && _lookingRight)
        {
            _lookingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_moveDirection.x > 0 && !_lookingRight)
        {
            _lookingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }

        _moveDirection.y -= gravity * Time.deltaTime;

        _characterController.Move(_moveDirection * Time.deltaTime);
        _anim.SetBool("isGrounded", _characterController.isGrounded);
        _anim.SetFloat("Speed", Mathf.Abs(_moveDirection.x));
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Moving")
        {
            if (transform.parent == null)
            {
                transform.parent = collision.gameObject.transform;
            }
        }
        else if (collision.tag == "Respawner")
        {
            _characterController.enabled = false;
            transform.position = spawnPos;
            _characterController.enabled = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Moving")
        {
            if (transform.parent != null)
            {
                transform.parent = null;
            }
        }
    }


}

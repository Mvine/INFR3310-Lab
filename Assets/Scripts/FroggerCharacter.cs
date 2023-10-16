using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggerCharacter : MonoBehaviour
{



    Rigidbody2D m_Rigidbody = null;
    Collider2D m_Collider = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector3.right);
        }
    }

    private void Move(Vector3 a_Direction)
    {
        transform.position += a_Direction;
    }
}

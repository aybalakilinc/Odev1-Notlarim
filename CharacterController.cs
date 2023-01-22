using System.Collections;
using System.Collections.Generic;  
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _camera;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); //caching
        r2d = GetComponent<Rigidbody2D>(); //caching
        _animator = GetComponent<Animator>(); //caching
        charPos = transform.position;
    }

    private void FixedUpdate() //50fps saniyede 50 kere
    {
       // r2d.velocity = new Vector2(speed, 0f);
    }

    void Update() //update fonksiyonu her frame calisir
    { 
       /* if(Input.GetKey(KeyCode.Space))
      {
          speed = 1.0f;
         // Debug.Log("Hız 1.0f");
      }  
      else
      {
          speed = 0.0f;
         // Debug.Log("Hız 0.0f");
      } */
       
       charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);
      transform.position = charPos;
      //_animator.SetFloat("speed",speed);
      //r2d.velocity = new Vector2(speed, 0f); (fixed update taşıdım)

      if (Input.GetAxis("Horizontal") == 0.0f)
      {
          _animator.SetFloat("speed",0.0f);
      }
      else
      {
          _animator.SetFloat("speed",1.0f);
      }

      if (Input.GetAxis("Horizontal") > 0.01f)
      {
          _spriteRenderer.flipX = false;
      }
      else if (Input.GetAxis("Horizontal") < -0.01f)
      {
          _spriteRenderer.flipX = true;
      }



    }

    private void LateUpdate()
    {
       // _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);
    }
}

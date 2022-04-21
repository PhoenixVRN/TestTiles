using UnityEngine;

public class MotionTiles : MonoBehaviour
{
   public int speed;
   public InputManager InputManager;

   private Vector3 _transform;

   private void Start()
   {
      _transform = transform.position;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.A))
      {
         transform.position += Vector3.left * speed * Time.deltaTime/2;
      }
      else if (Input.GetKeyDown(KeyCode.D))
      {
         transform.position += Vector3.right * speed * Time.deltaTime/2;
      }
      else if (Input.GetKeyDown(KeyCode.W))
      {
         transform.position += Vector3.up * speed * Time.deltaTime/2;
      }
      else if (Input.GetKeyDown(KeyCode.S))
      {
         transform.position += Vector3.down * speed * Time.deltaTime/2;
      }

      if (_transform != transform.position)
      {
        InputManager.OutInfo();
        _transform = transform.position;
      } 
   }
}

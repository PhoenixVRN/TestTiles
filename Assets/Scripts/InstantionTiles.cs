using UnityEngine;

public class InstantionTiles : MonoBehaviour
{
   public Transform tiles;
   public Transform parent;
   private InputManager _inputManager;

   private void Start()
   {
      _inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
   }

   public void InstantiateTiles()
   {
      DestroyAllChild();
      
      var l = parent.transform;
      l.rotation = Quaternion.Euler(0, 0, 0);
      
      tiles.localScale = new Vector3(_inputManager._widthTile, _inputManager._heightTile, 0.1f);
      
      float a = _inputManager._widthTile  + _inputManager._seamSize;
      float b = _inputManager._heightTile + _inputManager._seamSize;
      float offset = _inputManager._tileOffset;
      float g = -2.5f;
      float h = g;
      for (float y = -1.5f; y < 1.5f; y = y + b)
      {
         for (float x = g; x < 2.5f; x = x + a)
         {
           var c = Instantiate(tiles, new Vector3(x, y, 0), Quaternion.identity, parent);
         }
         g = h  + offset;
         h = g;
      }
      l.rotation = Quaternion.Euler(0, 0, _inputManager._tileRotationAngle);
      _inputManager.OutInfo();
   }

   public void DestroyAllChild()
   {
      foreach (Transform child in transform) Destroy(child.gameObject);
   }
}

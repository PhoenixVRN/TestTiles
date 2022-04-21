using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
   public float _heightWall = 1;
   public float _widthWall = 1;
   public float _heightTile = 0.1f;
   public float _widthTile = 0.1f;
   public float _seamSize = 0.005f;
   public int _tileRotationAngle = 0;
   public float _tileOffset = 0;
   public OverlapBoxExample countTiles;
   public InstantionTiles InstantionTiles;
   public Text _textOutCountTiles;
   public Text _textOutSquareTiles;


    [SerializeField] private InputField _inputHeightWall;
    [SerializeField] private InputField _inputWidthWall;
    [SerializeField] private InputField _inputHeightTile;
    [SerializeField] private InputField _inputWidthTile;
    [SerializeField] private InputField _inputSeamSize;
    [SerializeField] private InputField _inputTileRotationAngle;
    [SerializeField] private InputField _inputTileOffset;

    [SerializeField] private GameObject _wall;
    [SerializeField] private GameObject _tile;
    
    private CultureInfo ruRu;
    private CultureInfo enUS = System.Globalization.CultureInfo.GetCultureInfo("en-US");
    

    public void SetWallHeight()
    {
        if (PointCheck(_inputHeightWall.text)) return; // TODO реализовать подсказку что вмето точки ","
        _heightWall = float.Parse(_inputHeightWall.text, enUS);
        if (_heightWall < 0) return;
        var f =_wall.GetComponent<Transform>();
        f.localScale = new Vector3(_widthWall, _heightWall, 0.1f);
        InstantionTiles.InstantiateTiles();
    }
    
    public void SetWallWidth()
    {
        if (PointCheck(_inputWidthWall.text)) return; // TODO реализовать подсказку что вмето точки ","
        _widthWall = float.Parse( _inputWidthWall.text, enUS);
        if (_widthWall < 0) return;
        var f = _wall.GetComponent<Transform>();
        f.localScale = new Vector3(_widthWall, _heightWall, 0.1f);
        InstantionTiles.InstantiateTiles();
    }

    public void SetTileHeight()
    {
        if (PointCheck(_inputHeightTile.text)) return; // TODO реализовать подсказку что вмето точки ","
        _heightTile = float.Parse(_inputHeightTile.text, enUS);
        InstantionTiles.InstantiateTiles();
    }
    
    public void SetTileWidh()
    {
        if (PointCheck(_inputWidthTile.text)) return; // TODO реализовать подсказку что вмето точки ","
        _widthTile = float.Parse( _inputWidthTile.text, enUS);
        InstantionTiles.InstantiateTiles();
    }

    public void SetSeamSize()
    {
        if (PointCheck(_inputSeamSize.text) || PointCheck(_inputSeamSize.text)) return; // TODO реализовать подсказку что вмето точки ","
        _seamSize = float.Parse(_inputSeamSize.text, enUS);
        InstantionTiles.InstantiateTiles();
    }

    public void RotationTiles()
    {
        if (PointCheck(_inputTileRotationAngle.text) || PointCheck(_inputTileRotationAngle.text)) return; // TODO реализовать подсказку что вмето точки ","
         _tileRotationAngle = int.Parse(_inputTileRotationAngle.text, enUS);
       var l = _tile.transform;
           l.rotation = Quaternion.Euler(0, 0, _tileRotationAngle);
    }
    
    public void SetTileOffset()
    {
        if (PointCheck(_inputTileOffset.text) || PointCheck(_inputTileOffset.text)) return; // TODO реализовать подсказку что вмето точки ","
        _tileOffset = float.Parse(_inputTileOffset.text, enUS);
        InstantionTiles.InstantiateTiles();
    }

    private bool PointCheck(string input) // проверяем на наличие запятой или ничего в вводе
    {
        if (input.Contains(',') || input == "") return true;
        else return false;
    }

    public void OutInfo()
    {
        var i = countTiles.MyCollisions();
        _textOutCountTiles.text = i.ToString();
        var a = (_heightTile * _widthTile) * i;
        _textOutSquareTiles.text = a.ToString();
    }
}

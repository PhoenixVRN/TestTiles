using System.Collections.Generic;
using UnityEngine;

public class OverlapBoxExample : MonoBehaviour
{

    public Collider2D chekZone;
    public ContactFilter2D filtr;
    

    public int MyCollisions()
    {
        var a = Physics2D.OverlapCollider(chekZone,  filtr, new List<Collider2D>());
        return a;
    }
}

using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private int speed;
    [HideInInspector]public NoteManager manager;
    public void OnEnable()
    {
        manager = NoteManager.Instance;
        speed = manager.NoteSpeed;
    }
    public void Update()
    {
        Move();
    }
    public void Move()
    {

        if (manager.PlayPaused) return;

        Vector3 velocity = new Vector3(-speed * Time.deltaTime, 0);
        this.transform.Translate(velocity);
    }
   
}

using System;
using UnityEngine;

public class MovableWall : MonoBehaviour
{
   [SerializeField] private Animator _anim;
   [SerializeField] private bool _open;

   private void Start()
   {
      _open = false;
   }

   private void Update()
   {
      if (_open)
      {
         _anim.SetTrigger("MoveWall");
      }
   }

   public void SetMovableWallTrigger()
   {
      _open = true;
   }
}

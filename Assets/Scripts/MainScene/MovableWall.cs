using System;
using UnityEngine;

public class MovableWall : MonoBehaviour
{
   [SerializeField] private Animator _anim;
   [SerializeField] private bool _open;
   [SerializeField] private int _wallIndex;
   [SerializeField] private AudioSource _audioSource;

   private void Start()
   {
      _open = false;
   }

   private void Update()
   {
        if(_wallIndex == 1)
        {
            if (_open)
            {
                _anim.SetTrigger("MoveWall");
            }
        } else
        {
            if (_open)
            {
                _anim.SetTrigger("MoveWall2");
            }
        }
     
   }

   public void SetMovableWallTrigger()
   {
      _open = true;
   }

    public void Test()
    {
        Debug.Log("Looking");
    }

    public void PlayStonePushSound()
    {
        _audioSource.Play();
    }
}

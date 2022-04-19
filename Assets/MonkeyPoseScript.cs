using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyPoseScript : MonoBehaviour
{
    private Animator _animator;

    public bool sit1 = false;
    public bool sit2 = false;
    public bool hang1 = false;
    public bool hang2 = false;

    private void Awake()
    {
        if (!_animator)
        {
            _animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        _animator.SetBool("MonkeyHang", hang1);
        _animator.SetBool("MonkeyHang2", hang2);
        _animator.SetBool("MonkeySit", sit1);
        _animator.SetBool("MonkeySit2", sit2);
    }
}

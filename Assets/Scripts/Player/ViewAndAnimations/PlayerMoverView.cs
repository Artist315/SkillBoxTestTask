using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoverView : MonoBehaviour
{
    public Animator _animator;

    private Player _player;
    //private ProgressBarView _progressBar;

    private void Awake()
    {
        _player = Player.Instance;

        _animator = Player.Instance.GetComponentInChildren<Animator>() ?? throw new Exception(nameof(Animator));
        //_progressBar = Player.Instance.GetComponentInChildren<ProgressBarView>() ?? throw new Exception(nameof(ProgressBarView));

    }
    public void SetAnimation(string name, int value)
    {
        _animator.SetInteger(name, value);
    }

    public void Move(Vector3 diff)
    {
        _player.transform.position += diff * 1;
    }

    internal void LookAt(Transform target)
    {
        _player.transform.LookAt(target.transform);
    }
    internal void LookAt(Vector3 target)
    {
        _player.transform.LookAt(target);
    }

    //public void StartProgressBar(float duration)
    //{
    //    _progressBar.StartTimer(duration);
    //}
    //public void StopProgressBar()
    //{
    //    _progressBar.Abort();
    //}
}

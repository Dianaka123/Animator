using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class GunsManager : MonoBehaviour
{
    [SerializeField] private AnimationClip newZoom;
    
    [SerializeField] private Button Ak74Btn;
    [SerializeField] private Button SiFiBtn;
    [SerializeField] private Button MG61Btn;
    [SerializeField] private Button DoubleBarellBtn;

    [SerializeField] private GameObject AK74;
    [SerializeField] private GameObject SiFi;
    [SerializeField] private GameObject MG61;
    [SerializeField] private GameObject DoubleBarell;
    [SerializeField] private GameObject Weapon;

    private Animator _animator;
    private AnimatorOverrideController _overrideController;

    private int isZoomParameter = Animator.StringToHash("isZoom");
    private int isShootParameter = Animator.StringToHash("isShoot");
    private int ShootParameter = Animator.StringToHash("Shoot");
    private int isMovingParameter = Animator.StringToHash("isMoving");

    void Start()
    {
        _animator = GetComponent<Animator>();
        
        Ak74Btn.onClick.AddListener(() => ActivateGun(AK74, SiFi, MG61, DoubleBarell));
        SiFiBtn.onClick.AddListener(() => ActivateGun(SiFi, AK74, MG61, DoubleBarell));
        MG61Btn.onClick.AddListener(() => ActivateGun(MG61, AK74, SiFi, DoubleBarell));
        DoubleBarellBtn.onClick.AddListener(() => ActivateGun(DoubleBarell, AK74, MG61, SiFi));
    }

    private void Update()
    {
        //Shoot
        if (Input.GetMouseButtonDown(0))
        {
            Weapon.SetActive(true);
            _animator.SetFloat(ShootParameter, 1);
            _animator.SetBool(isShootParameter, true);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            Weapon.SetActive(false);
            _animator.SetFloat(ShootParameter, 0);
            _animator.SetBool(isShootParameter, false);
        }
        
        //Zoom
        if (Input.GetMouseButtonDown(1))
        {
            _animator.SetBool(isZoomParameter, true);
        }
        
        if (Input.GetMouseButtonUp(1))
        {
            _animator.SetBool(isZoomParameter, false);
        }

        //Moving
        if (Input.GetKeyDown(KeyCode.W))
        {
            var layerIndex = _animator.GetLayerIndex("Moving");
            _animator.SetBool(isMovingParameter, true);
            _animator.SetLayerWeight(layerIndex, 0.4f);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            var layerIndex = _animator.GetLayerIndex("Moving");
            _animator.SetLayerWeight(layerIndex, 0);
            _animator.SetBool(isMovingParameter, false);
        }
    }
    
    private void ActivateGun(GameObject activate, params GameObject[] deactivate)
    {
        activate.SetActive(true);
        foreach (var obj in deactivate)
        {
            obj.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        Ak74Btn.onClick.RemoveAllListeners();
        SiFiBtn.onClick.RemoveAllListeners();
        MG61Btn.onClick.RemoveAllListeners();
        DoubleBarellBtn.onClick.RemoveAllListeners();
    }
}

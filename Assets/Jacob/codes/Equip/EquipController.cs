using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EquipController : MonoBehaviour
{
    private EquipItem curEquipItem;
    private GameObject curEquipObject;

    private bool useInput;

    [Header("Components")]
    [SerializeField] private Transform equipObjectOrigin;
    [SerializeField] private MouseUtilities mouseUtilities;
}

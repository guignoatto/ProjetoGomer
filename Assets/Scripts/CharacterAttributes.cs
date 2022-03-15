using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterAttribute", menuName = "CharacterAttribute", order = 1)]
public class CharacterAttributes : ScriptableObject
{
    [SerializeField] private float _pullForce;
    [SerializeField] private float _usualGravity;
    [SerializeField] private PhysicsMaterial2D _physicsMaterial;

    public float PullForce { get => _pullForce; set => _pullForce = value; }
    public float UsualGravity { get => _usualGravity; set => _usualGravity = value; }
    public PhysicsMaterial2D PhysicsMaterial { get => _physicsMaterial; set => _physicsMaterial = value; }
}

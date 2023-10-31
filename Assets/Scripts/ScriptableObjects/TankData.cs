using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TankData : ScriptableObject
{
   [SerializeField] private float jumpForce;
   [SerializeField] private float movementSpeed;
   [SerializeField] private int lives;

}

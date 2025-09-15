using Assets.Scripts.Runtime.Shared.Interfaces.Data;
using UnityEngine;

namespace Assets.Scripts.Runtime.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Shooting Position Data", menuName = "Scriptable Objects/Data/ShootingPositionData")]
    public class SO_ShootingPositionData : ScriptableObject, IShootingPositionData
    {
        [SerializeField] private Vector3[] shootingPositionArray;

        public Vector3[] ShootingPositions => shootingPositionArray;
    }
}
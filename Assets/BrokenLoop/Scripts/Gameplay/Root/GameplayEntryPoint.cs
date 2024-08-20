using BrokenLoop.Scripts.Gameplay;
using BrokenLoop.Scripts.Gameplay.Buildings;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private Player _player;
        private Portal _portal;
        private TronBuilding _tron;
        
        public void Run()
        {
            _player = Instantiate(Resources.Load<Player>("Player"));
            _portal = Instantiate(Resources.Load<Portal>("Portal"), new Vector3(6.5f, -6.5f, 0), Quaternion.identity);
            _tron = (TronBuilding)BuildingsFactory.Instance.CreateInstance(EBuildingType.Tron, new Vector2(-0.5f, 7.5f));
            
            Debug.Log("Gameplay scene loaded");
        }
    }
}
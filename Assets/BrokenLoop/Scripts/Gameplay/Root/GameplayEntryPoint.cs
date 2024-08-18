using BrokenLoop.Scripts.Gameplay;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private Player _player;
        
        public void Run()
        {
            _player = Instantiate(Resources.Load<Player>("Player"));
            Debug.Log("Gameplay scene loaded");
        }
    }
}
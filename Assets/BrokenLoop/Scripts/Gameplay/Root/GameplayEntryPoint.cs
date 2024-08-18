using BrokenLoop.Scripts.Gameplay;
using UnityEngine;

namespace BrokenLoop.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private Player _player;
        private Portal _portal;
        
        public void Run()
        {
            _player = Instantiate(Resources.Load<Player>("Player"));
            _portal = Instantiate(Resources.Load<Portal>("Portal"), new Vector3(4.5f, 2.5f, 0), Quaternion.identity);
            Debug.Log("Gameplay scene loaded");
        }
    }
}
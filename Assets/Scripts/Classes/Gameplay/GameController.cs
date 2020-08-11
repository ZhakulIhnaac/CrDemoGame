using Assets.Scripts.Classes.UI;
using UnityEngine;

namespace Assets.Scripts.Classes.Gameplay
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }
}
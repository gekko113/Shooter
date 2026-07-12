using UnityEngine;

namespace My_Game.Scripts
{
    public class GameStart : MonoBehaviour
    {
        [SerializeField] private CharacterStart characterStart;
        [SerializeField] private InputStart inputStart;
        
        
        private void Start()
        {
            inputStart.Init();
            characterStart.Init(inputStart.InputUser);
        }
    }
}

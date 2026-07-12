using UnityEngine;

namespace My_Game.Scripts
{
    public class InputStart :  MonoBehaviour
    {
        public InputUser InputUser { get; private set; }
        [SerializeField] private GameObject prefab;
        
        public void Init()
        {
            var input = Instantiate(prefab);
            InputUser = input.GetComponent<InputUser>();
        }
    }
}
using Cysharp.Threading.Tasks;
using TriInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

[HideMonoScript]
public class Initializer : MonoBehaviour
{

    [Scene][SerializeField] private string[] gameScenes;
    
    private void Start()
    {
        MasterScript.Settings = Resources.Load<GameSettings>("GameSettings");
    }
}

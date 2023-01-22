using UnityEngine;

public class ShadersController : MonoBehaviour
{
    [SerializeField]
    private GrayscaleControl grayscaleControl;

    
    void Awake()
    {
        grayscaleControl.StartGrayscaleRoutine();
    }
}

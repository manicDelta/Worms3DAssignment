using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOverviewCamera : MonoBehaviour
{

    [SerializeField] private Camera _overviewCamera;
    private Camera _mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCamera();
    }

    private void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Checking which camera is the current active one and switches the non active to be active
            if (_overviewCamera.depth < _mainCamera.depth)
            {
                _overviewCamera.depth = _mainCamera.depth + 1;
            }
            else
            {
                _overviewCamera.depth = _mainCamera.depth - 1;
            }
        }
    }
}

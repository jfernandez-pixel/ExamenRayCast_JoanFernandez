using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    InputAction _mouseClick;
    Vector2 _mousePosition;
    InputAction _positionInput;


    [SerializeField]private Text _timerText;
    float _timer = 0f;
    bool _isCounting = false;
    private int _changeScene;


    void Awake()
    {
        _mouseClick = InputSystem.actions["Attack"];
        _positionInput = InputSystem.actions["MousePosition"];
    }
    void Update()
    {
        _mousePosition = _positionInput.ReadValue<Vector2>();
        if(_mouseClick.WasPressedThisFrame())
        {
            ShootRayCast();
        }

        if (_isCounting)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                _timer = Mathf.Max(0, _timer);

                _timerText.text = _timer.ToString("F1");
            }
            if (_timer <= 0)
            {
                _isCounting = false;
                SceneManager.LoadScene(_changeScene);
            }

    }
    void ShootRayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.name == "Objeto1")
            {
                _changeScene = 1;
            }
           if (hit.collider.gameObject.name == "Objeto2")
            {
                _changeScene = 2;
            }
            if (hit.collider.gameObject.name == "Objeto3")
            {
                _changeScene = 3;
            }
            _timer = 5f;
            _isCounting = true;
        }
    }
    }
}

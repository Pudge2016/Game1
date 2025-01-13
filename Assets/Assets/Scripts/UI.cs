using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private tankmovement tankMovement;
    private FloatField tankSpeed;

    // Start is called before the first frame update
    void Start()
    {
        tankMovement = FindObjectOfType<tankmovement>();

        // Знаходимо прогрес-бар
        VisualElement visualElement = GetComponent<UIDocument>().rootVisualElement;
        tankSpeed = visualElement.Q<FloatField>("TankSpeed");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(tankMovement.CurrentSpeed);
        tankSpeed.value = tankMovement.CurrentSpeed;
        if (tankMovement != null && tankSpeed != null)
        {
            // Оновлюємо значення прогрес-бару
           
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    
    [SerializeField] private Text t_text;
    private float _timer = 0f;
    public float duration = 30f;

    // Update is called once per frame
    void Update() {
        duration -= Time.deltaTime;
        t_text.text = $"Time left: {Mathf.Round(duration)}";

        if(duration < 0) {
//            Application.LoadLevel("gameOver");
            Debug.Log("Lá vem wave");
        }
    }
}

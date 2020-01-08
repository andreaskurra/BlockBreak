using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class PointerRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    public UnityEvent onLongClick;

    [SerializeField] Paddle paddle1;
    //[SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1.803f;
    [SerializeField] float maxX = 19.48f;
    [SerializeField] float accelarator = 1f;
    private float currentPos;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            currentPos = paddle1.transform.position.x + pointerDownTimer * accelarator;
            Debug.Log("Right " + pointerDownTimer);
            paddlePos.x = Mathf.Clamp(currentPos, minX, maxX);
            paddle1.transform.position = paddlePos;
        }


    }

    void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }
}

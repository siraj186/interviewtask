using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    protected override void Start()
    {
        base.Start();
       // background.gameObject.SetActive(false);

    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        //if (PlayerController.Instance.isDead || GameManager.Instance.isLevelComplete)
        //    return;

        //if(GameManager.Instance.helpHand.activeInHierarchy)
        //{
        //    GameManager.Instance.helpHand.SetActive(false);
        //}
        //PlayerController.Instance.ResumeCharacter();
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //if (PlayerController.Instance.isAlreadyDead || GameManager.Instance.isLevelComplete)
        //    return;

        //PlayerController.Instance.PauseCharacter();
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public enum ElementType
{
    Rock, // = 0
    Scissors, // = 1
    Dynamite // = 2
}*/
public class Element : MonoBehaviour
{
    public ElementType elementSO;

    private void Start()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = elementSO.icon;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Element>(out Element element))
        {
            //If the collided object is weak against our type
            if (element.elementSO.weaknesses.Contains(this.elementSO))
            {
                Destroy(element.gameObject);
            }
            //If we collided with an element we're weak against
            if (elementSO.weaknesses.Contains(element.elementSO))
            {
                Destroy(this.gameObject);
            }
        }
    }
}

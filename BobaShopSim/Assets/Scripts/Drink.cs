using System;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    public List<string> attributes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddAttribute(string attribute)
    {
        if (attributes == null)
        {
            attributes = new List<string> { attribute };
        }
        else
        {
            attributes.Add(attribute);
        }
    }

    public void RemoveAttribute(string attribute)
    {
        if (attributes != null && attributes.Contains(attribute))
        {
            attributes.Remove(attribute);
        }
    }

    public bool CheckComplete(List<string> requiredAttributes)
    {
        if (attributes == null || requiredAttributes == null)
        {
            return false;
        }

        foreach (string requiredAttribute in requiredAttributes)
        {
            if (!attributes.Contains(requiredAttribute))
            {
                return false;
            }
        }

        return true;
    }
}

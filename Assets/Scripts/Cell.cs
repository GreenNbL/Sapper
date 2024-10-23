using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Generation gen;
    [SerializeField] private Vector2Int genPosition;
    [SerializeField] public int number;
    [SerializeField] private Transform numSpawn;
    [SerializeField] private bool opened;
    [SerializeField] private GameObject[] nums;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject flag;
    [SerializeField] private bool flagged=false;
    [SerializeField] private GameObject outline;

    public void Gen(Generation gen, Vector2Int genPosition )
    {
        this.gen = gen;
        this.genPosition = genPosition;

    }
    public void Start()
    {
        outline.SetActive(false);
        flag.SetActive(flagged);
    }
    public void SetNum(int num)
    {
        number = num;
    }
    private void OnMouseOver()
    {
        if(shield.activeSelf && !opened)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !flagged)
                OpenCell();
            else if (Input.GetKeyDown(KeyCode.Mouse1))
                FlaggCell();
        }
       
    }
    public void OpenCell()
    { 
        if (opened)
            return;
        opened = true;
        shield.SetActive(false);
       
        if(number ==0)
        {
            gen.OpenEmpty(genPosition);
        }
        if(number > 0 && number < nums.Length+1 )
        {
            Instantiate(nums[number-1],numSpawn.position, Quaternion.identity, numSpawn);
            
        }
        if (number < 0)
        {
            Debug.Log("QQBOM");
        }

    }
    private void OnMouseEnter()
    {
        outline.SetActive(true);
    }
    private void OnMouseExit()
    {
        outline.SetActive(false);
    }
    private void FlaggCell()
    {
        flagged=!flagged;
        flag.SetActive(flagged);
    }
    
}

using UnityEngine;
using UnityEngine.InputSystem;

public abstract class c_ctSt_Class
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void EnterState(c_CatController player);

    // Update is called once per frame
    public abstract void UpdateState(c_CatController player);
}
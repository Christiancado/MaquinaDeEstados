using UnityEngine;
using System.Collections;

public abstract class State   {

    protected IFSMcontext context;

    /*I only needed onUpdate that´s because*/
    public abstract void onUpdate();
}

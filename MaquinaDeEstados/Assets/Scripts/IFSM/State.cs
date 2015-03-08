using UnityEngine;
using System.Collections;

public abstract class State   {

    protected IFSMcontext context;

    public abstract void onUpdate();
}

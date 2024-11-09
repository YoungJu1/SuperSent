using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameControlBase : TypeClass
{
    protected Action m_callback = null;

    public virtual void Init(ManagerType _type)
    {
        myType = _type;
        m_callback = Open;
    }

    public virtual void Open()
    {
    }

    public virtual void Callback()
    {
        if (m_callback == null) return;

        m_callback.Invoke();
    }
}

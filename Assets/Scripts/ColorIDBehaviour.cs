using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorIDBehaviour : IDHolderBehaviour
{
    public ColorIDDataList colorIDDataListObj;

    private void Awake()
    {
        idObj = colorIDDataListObj.currentColor;
    }
}
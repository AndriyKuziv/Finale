using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFoo
{
    void create(float x, float y);
    void setPosition(Transform obj, float x, float y);
    void affect();
    void yeet();
}

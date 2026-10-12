using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class playerFloatMov : MonoBehaviour
{
    public ParentConstraint constraint;
    public bool isOffsetSet;
    private float offset;
    private Vector3 initialOffset;
    public GameObject flyGround;

    void Start()
    {
        constraint = GetComponent<ParentConstraint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (constraint.constraintActive)
        {
            if (!isOffsetSet)
            {
                initialOffset = transform.position - flyGround.transform.position;
                SetConstraintOffsets();
                isOffsetSet = true;
            }
        }
        else
        {
            isOffsetSet = false;
        }

        void SetConstraintOffsets()
        {
            ConstraintSource source = new ConstraintSource();
            source.sourceTransform = flyGround.transform;
            source.weight = 1.0f;
            constraint.SetSource(0, source);
            constraint.SetTranslationOffset(0, initialOffset);
        }
    }
}


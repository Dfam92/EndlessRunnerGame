using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;

    [SerializeField] DecorationSpawner decoratrionSpawner;
    public Transform Start => start;
    public Transform End => end;
}

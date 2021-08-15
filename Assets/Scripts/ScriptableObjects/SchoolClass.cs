using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New School Class", menuName = "School/School Class")]
public class SchoolClass : ScriptableObject
{
    public new string name;
    public Student[] students;
    public Teacher teacher;
    public Lesson[] timetable;
}

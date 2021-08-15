using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SchoolManager : MonoBehaviour
{
    public static SchoolManager current;

    public Transform studentSpawnPoint;
    public GameObject studentPrefab;

    public SchoolClass[] classes;
    // private SchoolClubs[] clubs = ...
    public Classroom[] classrooms;

    private void Awake()
    {
        current = this;
    }

	private void Start()
	{
        SpawnStudents();
	}

    public Transform GetClassroom(Subject subject)
	{
        return classrooms.SingleOrDefault(c => c.subject == subject).transform;
	}

    private void SpawnStudents()
	{
        foreach (SchoolClass schoolClass in classes)
        {
            foreach (Student student in schoolClass.students)
            {
                GameObject studentObject = Instantiate(studentPrefab,
                    studentSpawnPoint.position + new Vector3(Random.Range(-5, 5), 0, 0), Quaternion.identity);

                studentObject.name = $"{student.firstname} {student.lastname}";
                studentObject.GetComponent<StudentAI>().SetData(student, schoolClass.timetable);
            }
        }
	}
}

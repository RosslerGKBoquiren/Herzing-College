' A structure represents the student's information
Structure Student
    Dim StudentID As Integer
    Dim FirstName As String
    Dim LastName As String
    Dim Age As Integer
    Dim Program As String
    Dim Teacher As String
End Structure

' The main program logic
Module StudentManager

    ' Generate a unique student ID using a static counter
    Dim lastStudentID As Integer = 9999 ' Initialize the starting ID
    Function GenerateStudentId() As Integer
        lastStudentID += 1
        Return lastStudentID
    End Function

    ' The list holds student records
    Dim students As New List(Of Student)()

    Sub Main()

        InitializeSampleStudents()

        Dim choice As Integer
        Do
            Console.Clear()
            Console.WriteLine(Environment.NewLine & "Welcome to Student Management System!" & Environment.NewLine)
            Console.WriteLine("1. Add a New Student")
            Console.WriteLine("2. Remove a Student")
            Console.WriteLine("3. Edit a Student")
            Console.WriteLine("4. Display All Students")
            Console.WriteLine("5. Exit" & Environment.NewLine)
            Console.Write("Enter the number of your choice: ")
            Integer.TryParse(Console.ReadLine(), choice)

            Select Case choice
                Case 1 : AddStudent()
                Case 2 : RemoveStudent()
                Case 3 : EditStudent()
                Case 4 : DisplayStudent()
                Case 5 : Exit Do
                Case Else : Console.WriteLine(Environment.NewLine & "Invalid choice. Please try again.")
            End Select
            Console.WriteLine(Environment.NewLine & "Press any key to return to the main menu...")
            Console.ReadKey()
        Loop
    End Sub



    ' Initialize the list with sample student data
    Sub InitializeSampleStudents()
        students.Add(New Student With {
            .StudentID = GenerateStudentId(),
            .FirstName = "Ross",
            .LastName = "Doe",
            .Age = 20,
            .Program = "ENGL101",
            .Teacher = "LeBron"
        })
        students.Add(New Student With {
            .StudentID = GenerateStudentId(),
            .FirstName = "Janine",
            .LastName = "Smith",
            .Age = 22,
            .Program = "COMP203",
            .Teacher = "Curry"
        })
        students.Add(New Student With {
            .StudentID = GenerateStudentId(),
            .FirstName = "Alice",
            .LastName = "Wonder",
            .Age = 19,
            .Program = "MATH301",
            .Teacher = "Davis"
        })
        students.Add(New Student With {
            .StudentID = GenerateStudentId(),
            .FirstName = "Bob",
            .LastName = "Baker",
            .Age = 21,
            .Program = "SCIE102",
            .Teacher = "Miller"
        })

        Console.WriteLine(Environment.NewLine & "Sample students have been added to the system.")
    End Sub


    ' Add a new student to the list
    Sub AddStudent()
        Try
            Dim newStudent As Student

            ' Generate a unique student ID
            newStudent.StudentID = GenerateStudentId()
            Console.WriteLine(Environment.NewLine & $"Generated Student ID: {newStudent.StudentID}")

            ' Validate First Name
            Do
                Console.Write(Environment.NewLine & "Enter First Name (letters only): ")
                Dim firstName = Console.ReadLine()
                If Not String.IsNullOrWhiteSpace(firstName) AndAlso firstName.All(AddressOf Char.IsLetter) Then
                    newStudent.FirstName = firstName
                    Exit Do
                Else
                    Console.WriteLine(Environment.NewLine & "Invalid input. First name must contain only letters.")
                End If
            Loop

            ' Validate Last Name
            Do
                Console.Write(Environment.NewLine & "Enter Last Name (letters only): ")
                Dim lastName = Console.ReadLine()
                If Not String.IsNullOrWhiteSpace(lastName) AndAlso lastName.All(AddressOf Char.IsLetter) Then
                    newStudent.LastName = lastName
                    Exit Do
                Else
                    Console.WriteLine(Environment.NewLine & "Invalid input. Last name must contain only letters.")
                End If
            Loop

            ' Validate Age
            Do
                Console.Write(Environment.NewLine & "Enter Age (non-negative number): ")
                Dim ageInput = Console.ReadLine()
                If Integer.TryParse(ageInput, newStudent.Age) AndAlso newStudent.Age >= 0 Then
                    Exit Do
                Else
                    Console.WriteLine(Environment.NewLine & "Invalid input. Age must be a non-negative number.")
                End If
            Loop

            ' Validate Program (4 letters followed by 3 digits)
            Dim programPattern As String = "^[A-Za-z]{4}\d{3}$" ' Regex pattern for 4 letters + 3 digits
            Do
                Console.Write(Environment.NewLine & "Enter Program (4 letters followed by 3 digits, e.g., COMP123): ")
                Dim program = Console.ReadLine()
                If Not String.IsNullOrWhiteSpace(program) AndAlso System.Text.RegularExpressions.Regex.IsMatch(program, programPattern) Then
                    newStudent.Program = program
                    Exit Do
                Else
                    Console.WriteLine(Environment.NewLine & "Invalid input. Program must be 4 letters followed by 3 digits.")
                End If
            Loop

            ' Validate Teacher (letters only)
            Do
                Console.Write(Environment.NewLine & "Enter Teacher Name (letters only): ")
                Dim teacher = Console.ReadLine()
                If Not String.IsNullOrWhiteSpace(teacher) AndAlso teacher.All(AddressOf Char.IsLetter) Then
                    newStudent.Teacher = teacher
                    Exit Do
                Else
                    Console.WriteLine(Environment.NewLine & "Invalid input. Teacher name must contain only letters.")
                End If
            Loop

            ' Add the new student to the list
            students.Add(newStudent)
            Console.WriteLine(Environment.NewLine & "Student added successfully!")
        Catch ex As Exception
            Console.WriteLine(Environment.NewLine & $"An error occurred: {ex.Message}")
        End Try
    End Sub


    ' Remove a student by StudentID
    Sub RemoveStudent()
        ' Display the current list of students
        DisplayStudent()

        If students.Count = 0 Then
            Console.WriteLine(Environment.NewLine & "No students available to remove.")
            Return
        End If

        ' Prompt for the ID of the student to remove
        Console.Write(Environment.NewLine & "Enter the ID of the student to be removed: ")
        Dim idToRemove As Integer
        If Not Integer.TryParse(Console.ReadLine(), idToRemove) Then
            Console.WriteLine(Environment.NewLine & "Invalid ID. Please enter a numeric ID.")
            Return
        End If

        ' Find the student by ID
        Dim studentIndex = students.FindIndex(Function(s) s.StudentID = idToRemove)

        If studentIndex >= 0 Then
            ' Confirm before removing the student
            Console.Write(Environment.NewLine & $"Are you sure you want to remove student ID {idToRemove}? (Y/N): ")
            Dim confirmation = Console.ReadLine().ToUpper()
            If confirmation = "Y" Then
                students.RemoveAt(studentIndex)
                Console.WriteLine(Environment.NewLine & "Student removed successfully!")
            Else
                Console.WriteLine(Environment.NewLine & "Operation cancelled.")
            End If
        Else
            Console.WriteLine(Environment.NewLine & "Student not found.")
        End If
    End Sub


    ' Edit a student's information
    Sub EditStudent()
        ' Display the current list of students
        DisplayStudent()

        If students.Count = 0 Then
            Console.WriteLine(Environment.NewLine & "No students available to edit.")
            Return
        End If

        ' Prompt for the ID of the student to edit
        Console.Write(Environment.NewLine & "Enter the ID of the student to be edited: ")
        Dim idToEdit As Integer
        If Not Integer.TryParse(Console.ReadLine(), idToEdit) Then
            Console.WriteLine(Environment.NewLine & "Invalid ID. Please enter a numeric ID.")
            Return
        End If

        ' Find the student by ID
        Dim studentIndex = students.FindIndex(Function(s) s.StudentID = idToEdit)

        If studentIndex >= 0 Then
            Dim student = students(studentIndex)
            Console.WriteLine(Environment.NewLine & $"Editing Student: {student.FirstName} {student.LastName}")

            ' Update fields with validation
            Console.Write(Environment.NewLine & "Enter new First Name (leave blank to keep current): ")
            Dim newFirstName = Console.ReadLine()
            If Not String.IsNullOrWhiteSpace(newFirstName) AndAlso newFirstName.All(AddressOf Char.IsLetter) Then
                student.FirstName = newFirstName
            ElseIf Not String.IsNullOrWhiteSpace(newFirstName) Then
                Console.WriteLine(Environment.NewLine & "Invalid input for First Name. Keeping current value.")
            End If

            Console.Write(Environment.NewLine & "Enter new Last Name (leave blank to keep current): ")
            Dim newLastName = Console.ReadLine()
            If Not String.IsNullOrWhiteSpace(newLastName) AndAlso newLastName.All(AddressOf Char.IsLetter) Then
                student.LastName = newLastName
            ElseIf Not String.IsNullOrWhiteSpace(newLastName) Then
                Console.WriteLine(Environment.NewLine & "Invalid input for Last Name. Keeping current value.")
            End If

            Console.Write(Environment.NewLine & "Enter new Age (leave blank to keep current): ")
            Dim newAgeInput = Console.ReadLine()
            If Not String.IsNullOrWhiteSpace(newAgeInput) AndAlso Integer.TryParse(newAgeInput, student.Age) AndAlso student.Age >= 0 Then
                student.Age = Integer.Parse(newAgeInput)
            ElseIf Not String.IsNullOrWhiteSpace(newAgeInput) Then
                Console.WriteLine(Environment.NewLine & "Invalid input for Age. Keeping current value.")
            End If

            Console.Write(Environment.NewLine & "Enter new Program (leave blank to keep current): ")
            Dim programPattern As String = "^[A-Za-z]{4}\d{3}$"
            Dim newProgram = Console.ReadLine()
            If Not String.IsNullOrWhiteSpace(newProgram) AndAlso System.Text.RegularExpressions.Regex.IsMatch(newProgram, programPattern) Then
                student.Program = newProgram
            ElseIf Not String.IsNullOrWhiteSpace(newProgram) Then
                Console.WriteLine(Environment.NewLine & "Invalid input for Program. Keeping current value.")
            End If

            Console.Write(Environment.NewLine & "Enter new Teacher (leave blank to keep current): ")
            Dim newTeacher = Console.ReadLine()
            If Not String.IsNullOrWhiteSpace(newTeacher) AndAlso newTeacher.All(AddressOf Char.IsLetter) Then
                student.Teacher = newTeacher
            ElseIf Not String.IsNullOrWhiteSpace(newTeacher) Then
                Console.WriteLine(Environment.NewLine & "Invalid input for Teacher. Keeping current value.")
            End If

            ' Save the updated student back to the list
            students(studentIndex) = student
            Console.WriteLine(Environment.NewLine & "Student updated successfully!")
        Else
            Console.WriteLine(Environment.NewLine & "Student not found.")
        End If
    End Sub


    ' Display all students
    Sub DisplayStudent()
        If students.Count = 0 Then
            Console.WriteLine(Environment.NewLine & "No students in the system.")
            Return
        End If

        Console.WriteLine(Environment.NewLine & "Student List:")
        Console.WriteLine(Environment.NewLine & "ID       First Name   Last Name       Age   Program         Teacher")
        Console.WriteLine(New String("-"c, 80))
        For Each student In students
            Console.WriteLine($"{student.StudentID,-8} {student.FirstName,-12} {student.LastName,-15} {student.Age,-5} {student.Program,-15} {student.Teacher}")
        Next
    End Sub

End Module


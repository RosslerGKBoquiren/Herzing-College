Module Module1
    Sub main()
        Dim mc1 As MyClass1 = New MyClass1
        mc1._name = "Juan"
        mc1.description()
        Dim mc2 As MyClass1 = New MyClass1("andy")
        Console.WriteLine(mc2._name)
        mc2.description()


        Dim st1 As Student = New Student
        st1.Age = 0
        st1.Program = "Programmer Analyst"
        st1.Name = "JJJ"

        st1.description()
        Console.WriteLine(st1.Name)

        Dim st2 As Student = New Student("Sam", 20, "PA")
        st2.description()












        Console.ReadKey()
    End Sub
End Module

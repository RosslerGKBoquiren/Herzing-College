Imports System.Text.RegularExpressions


Public Class Validation
    ' Validates user data and returns a string of errors (if any)
    Public Shared Function ValidateUser(user As User) As String
        Dim errors As String = ""

        ' Check Name
        If String.IsNullOrWhiteSpace(user.Name) Then
            errors &= "Name cannot be empty." & vbCrLf
        End If

        ' Check Email
        If String.IsNullOrWhiteSpace(user.Email) OrElse Not Regex.IsMatch(user.Email, "^\S+@\S+\.\S+$") Then
            errors &= "Invalid email format." & vbCrLf
        End If

        ' Check Password
        If String.IsNullOrWhiteSpace(user.Password) OrElse user.Password.Length < 6 Then
            errors &= "Password must be at least 6 characters long." & vbCrLf
        End If

        ' Check Gender
        If String.IsNullOrWhiteSpace(user.Gender) Then
            errors &= "Gender must be selected." & vbCrLf
        End If

        ' Check Address
        If String.IsNullOrWhiteSpace(user.Address) Then
            errors &= "Address cannot be empty." & vbCrLf
        End If

        ' Check Province
        If String.IsNullOrWhiteSpace(user.Province) OrElse user.Province = "Select a province" Then
            errors &= "Please select a province." & vbCrLf
        End If

        ' Check Country
        If String.IsNullOrWhiteSpace(user.Country) Then
            errors &= "Country cannot be empty." & vbCrLf
        End If

        ' Check Phone Number
        Dim cleanedPhone As String = user.PhoneNumber.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")
        If String.IsNullOrWhiteSpace(cleanedPhone) OrElse Not Regex.IsMatch(cleanedPhone, "^\d{10}$") Then
            errors &= "Phone number must be exactly 10 digits." & vbCrLf
        End If

        Return errors
    End Function
End Class

Imports System.ComponentModel.DataAnnotations
Imports MySql.Data.MySqlClient

Public Class RegistrationForm
    ' Form Controls
    Private txtName As TextBox
    Private txtEmail As TextBox
    Private txtPassword As TextBox
    Private txtAddress As TextBox
    Private txtCountry As TextBox
    Private txtPhoneNumber As MaskedTextBox
    Private cmbProvince As ComboBox
    Private rbtnMale As RadioButton
    Private rbtnFemale As RadioButton
    Private btnRegister As Button
    Private btnClear As Button

    Private dbManager As New Database()

    ' Form Initialization
    Private Sub RegistrationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "New Account Registration"
        Me.Size = New Drawing.Size(400, 450)

        ' Initialize controls
        InitializeControls()
    End Sub

    Private Sub InitializeControls()
        ' Name Field
        AddLabel("Name:", 20, 20)
        txtName = AddTextBox(150, 20)

        ' Email Field
        AddLabel("Email Address:", 20, 60)
        txtEmail = AddTextBox(150, 60)

        ' Password Field
        AddLabel("Password:", 20, 100)
        txtPassword = AddPasswordBox(150, 100)

        ' Gender Selection
        AddLabel("Gender:", 20, 140)
        rbtnMale = AddRadioButton("Male", 160, 140)
        rbtnFemale = AddRadioButton("Female", 270, 140)

        ' Address Field
        AddLabel("Address:", 20, 180)
        txtAddress = AddTextBox(150, 180)

        ' Province Dropdown
        AddLabel("Province:", 20, 220)
        cmbProvince = AddComboBox(150, 220, New String() {
            "Select a province", "Yukon", "Nunavut", "Northwest Territories",
            "Alberta", "British Columbia", "Manitoba", "New Brunswick",
            "Newfoundland and Labrador", "Nova Scotia", "Ontario",
            "Prince Edward Island", "Quebec", "Saskatchewan"
        })
        cmbProvince.SelectedIndex = 0

        ' Country Field
        AddLabel("Country:", 20, 260)
        txtCountry = AddTextBox(150, 260)

        ' Phone Number Field
        AddLabel("Phone #:", 20, 300)
        txtPhoneNumber = AddMaskedTextBox(150, 300, "(999) 000-0000")

        ' Register Button
        btnRegister = AddButton("Register", 100, 360)
        AddHandler btnRegister.Click, AddressOf BtnRegister_Click

        ' Clear Button
        btnClear = AddButton("Clear", 200, 360)
        AddHandler btnClear.Click, AddressOf BtnClear_Click
    End Sub

    ' Functions to create controls
    Private Sub AddLabel(text As String, x As Integer, y As Integer)
        Dim lbl As New Label With {
            .Text = text,
            .Location = New Drawing.Point(x, y)
        }
        Me.Controls.Add(lbl)
    End Sub

    Private Function AddTextBox(x As Integer, y As Integer) As TextBox
        Dim txt As New TextBox With {
            .Location = New Drawing.Point(x, y),
            .Width = 200
        }
        Me.Controls.Add(txt)
        Return txt
    End Function

    Private Function AddPasswordBox(x As Integer, y As Integer) As TextBox
        Dim txt As New TextBox With {
            .Location = New Drawing.Point(x, y),
            .Width = 200,
            .PasswordChar = "*"c
        }
        Me.Controls.Add(txt)
        Return txt
    End Function

    Private Function AddRadioButton(text As String, x As Integer, y As Integer) As RadioButton
        Dim rbtn As New RadioButton With {
            .Text = text,
            .Location = New Drawing.Point(x, y)
        }
        Me.Controls.Add(rbtn)
        Return rbtn
    End Function

    Private Function AddComboBox(x As Integer, y As Integer, items As String()) As ComboBox
        Dim cmb As New ComboBox With {
            .Location = New Drawing.Point(x, y),
            .Width = 200,
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        cmb.Items.AddRange(items)
        Me.Controls.Add(cmb)
        Return cmb
    End Function

    Private Function AddMaskedTextBox(x As Integer, y As Integer, mask As String) As MaskedTextBox
        Dim txt As New MaskedTextBox With {
            .Location = New Drawing.Point(x, y),
            .Width = 200,
            .Mask = mask
        }
        Me.Controls.Add(txt)
        Return txt
    End Function

    Private Function AddButton(text As String, x As Integer, y As Integer) As Button
        Dim btn As New Button With {
            .Text = text,
            .Location = New Drawing.Point(x, y),
            .Width = 80
        }
        Me.Controls.Add(btn)
        Return btn
    End Function

    ' Button Click Event
    Private Sub BtnRegister_Click(sender As Object, e As EventArgs)
        ' Collect user data
        Dim user As New User With {
            .Name = txtName.Text,
            .Email = txtEmail.Text,
            .Password = txtPassword.Text,
            .Gender = If(rbtnMale.Checked, "Male", If(rbtnFemale.Checked, "Female", "")),
            .Address = txtAddress.Text,
            .Province = cmbProvince.Text,
            .Country = txtCountry.Text,
            .PhoneNumber = txtPhoneNumber.Text
        }

        ' Validate user data
        Dim validationErrors = Validation.ValidateUser(user)
        If Not String.IsNullOrWhiteSpace(validationErrors) Then
            ' Highlight errors and display error message
            MessageBox.Show(validationErrors, "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Display confirmation message box
        Dim confirmationMessage As String =
            $"Please confirm your details:{vbCrLf}" &
            $"Name: {user.Name}{vbCrLf}" &
            $"Email: {user.Email}{vbCrLf}" &
            $"Gender: {user.Gender}{vbCrLf}" &
            $"Address: {user.Address}{vbCrLf}" &
            $"Province: {user.Province}{vbCrLf}" &
            $"Country: {user.Country}{vbCrLf}" &
            $"Phone: {user.PhoneNumber}"

        Dim result As DialogResult = MessageBox.Show(confirmationMessage, "Confirm Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Proceed to save to the database
            If dbManager.AddUser(user) Then
                MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed to save user to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Clear Button Click Event
    Private Sub BtnClear_Click(sender As Object, e As EventArgs)
        txtName.Clear()
        txtEmail.Clear()
        txtPassword.Clear()
        txtAddress.Clear()
        txtCountry.Clear()
        txtPhoneNumber.Clear()
        cmbProvince.SelectedIndex = 0
        rbtnMale.Checked = False
        rbtnFemale.Checked = False
    End Sub
End Class

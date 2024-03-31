
<?php
function checkVariablesForBlankFields($formData)
{
    // Loop through each form field
    foreach ($formData as $key => $value) {
        // Check if the value is blank
        if (empty($value)) {
            // Blank field found, return false indicating validation failure
            return false;
        }
    }

    // All fields are non-blank, return true indicating validation success
    return true;
}
?>
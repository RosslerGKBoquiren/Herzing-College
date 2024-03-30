<?php
function checkVariableForBlankFields($form_data) 
{
	foreach ($form_data as $key => $value) {
		if (empty($value)) {
			return false;
		}
	}
	return true;
}

?>
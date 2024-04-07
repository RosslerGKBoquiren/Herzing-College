<!DOCTYPE html>
<html lang="en">
<head>
	<title>Template</title>
	<style>
		body {
			font-family: Arial, sans-serif;
			background-color: lightblue;
			margin: 0;
		}
		
		.output_message {
			background-color: white;
			border: 1px solid black;
			border-radius: 5px;
			padding: 15px;
			margin-top: 20px;
			text-align: center;
		}

		.error_message {
			color: red;
		}

		.success_message {
			color: green;
		}

		
		#form-div {
			width: 50%;
			margin: 50px auto;
			background-color: whitesmoke;
			padding: 20px;
			border: solid black 1px;
			border-radius: 10px;
		}
		
		.form {
			max-width: 400px;
			margin: 0 auto;
			text-align: center;
		}
		
		label {
			display: block;
			margin-top: 10px;
			margin-bottom: 10px;
			text-align: left;
		}

		input, select {
			width: 100%;
			padding: 10px;
			margin-bottom: 15px;
			box-sizing: border-box;
		}
		
		#btnSubmit {
			width: 30%;
			margin-right: auto;
			margin-left: auto;
			background-color: green;
			color: white;
			padding: 10px 15px;
			border: none;
			border-radius: 5px;
		}

		#btnSubmit:hover {
			background-color: lightgreen;
		}

		.checkbox-div {
			display: flex;
			justify-content: center;
		}

		#accept_terms {
			width: 20px;
			margin-top: 12px;
		}
		
		#footer-div {
			position: fixed;
			bottom: 0;
			width: 100%;
			background-color: grey;
			color: white;
			padding: 20px;
			text-align: center;
		}

		#footer-div p {
			margin: 0;
		}

	</style>
</head>
<body>

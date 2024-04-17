<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Dashboard</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
    <header>
        <div class="header">
            <h1>Dashboard</h1>
        </div>
    </header>

    <nav>
        <div class="menu">
             <span><a href="login.php?logout=true">LOGOUT</a></span>
        </div>
    </nav>

    <div class="dashboard_content">
        <p>Welcome to your dashboard!</p>
    </div>

    <footer>
        <div id="footer-div">
            <p>&copy; <?php echo date("Y"); ?> Rossler Boquiren</p>
        </div>
    </footer>
</body>
</html>

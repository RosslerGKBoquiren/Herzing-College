-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 02, 2024 at 07:07 AM
-- Server version: 8.2.0
-- PHP Version: 7.4.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `store`
--

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `username` varchar(20) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `password` varchar(100) NOT NULL,
  `province` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `date_joined` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `photo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `username`, `first_name`, `last_name`, `password`, `province`, `email`, `date_joined`, `photo`) VALUES
(23, 'hashed963', 'Doug', 'Dimmer', 'c51eb75d9ef0e710efff1577771504361382dc50', 'Newfoundland & Labra', 'dougdimmer@yahoo.com', '2024-04-17 03:10:45', NULL),
(22, 'hashed852', 'Karen', 'Menager', '50a356cdf368b6a2789f7de86401d98ced01fb99', 'Saskatchewan', 'karenmenager@facebook.com', '2024-04-17 03:09:49', NULL),
(21, 'hashed741', 'Cynthia', 'Blast', '873b46dddcd02ca90c3b22aa6f34b3df0334559b', 'Alberta', 'cynthiablast@hotmail.com', '2024-04-17 03:08:52', NULL),
(20, 'hashed951', 'Antman', 'Cevalier', '63e594789d988b1615a94f265a350981b4090491', 'Quebec', 'antmancevalier@aon.com', '2024-04-17 03:07:48', NULL),
(19, 'hashed753', 'Aaron', 'Johnson', 'bb2867cf3a7f46da026e25b7382df2c28db7d1c1', 'Prince Edward Island', 'aaronjohnson@gmail.com', '2024-04-17 03:06:39', NULL),
(18, 'hashed456', 'Boy', 'Bougli', '9ae777debf994f7dd2441a768f8c5f670c3ecf66', 'Manitoba', 'boybougli@outlook.com', '2024-04-17 03:02:26', NULL),
(17, 'hashed123', 'Bob', 'Barker', 'bb2867cf3a7f46da026e25b7382df2c28db7d1c1', 'Manitoba', 'bobbarker@yahoo.ca', '2024-04-17 02:56:01', NULL),
(24, 'update_security654', 'Security1', 'Update1', '5ed216dd8f1ce41f7e1ede00e214515539268352', 'New Brunswick', 'security1update1@test.com', '2024-04-17 23:34:29', NULL),
(25, 'expressionemail123', 'Expression', 'Regular', '32aa75033017c0aebaa8c5cc369d5bfe8c75c3a0', 'Manitoba', 'expressionemail@test.com', '2024-04-19 19:10:11', NULL),
(31, 'CaptchaUser654', 'Captcha1', 'User2', '5ed216dd8f1ce41f7e1ede00e214515539268352', 'Manitoba', 'captchauser1@hotmail.com', '2024-04-25 00:38:03', NULL),
(30, 'CaptchaUser741', 'Catpcha', 'User', '873b46dddcd02ca90c3b22aa6f34b3df0334559b', 'Nova Scotia', 'captchauser@yahoo.ca', '2024-04-25 00:36:43', NULL),
(32, 'CaptchaUser654', 'Captcha1', 'User2', '5ed216dd8f1ce41f7e1ede00e214515539268352', 'Manitoba', 'captchauser1@hotmail.com', '2024-04-25 00:38:32', NULL);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Apr 18, 2024 at 06:54 PM
-- Server version: 8.2.0
-- PHP Version: 8.2.13

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
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `username`, `first_name`, `last_name`, `password`, `province`, `email`, `date_joined`) VALUES
(23, 'hashed963', 'Doug', 'Dimmer', 'c51eb75d9ef0e710efff1577771504361382dc50', 'Newfoundland & Labra', 'dougdimmer@yahoo.com', '2024-04-17 03:10:45'),
(22, 'hashed852', 'Caren', 'Menager', '50a356cdf368b6a2789f7de86401d98ced01fb99', 'Saskatchewan', 'carenmenager@facebook.com', '2024-04-17 03:09:49'),
(21, 'hashed741', 'Cynthia', 'Blast', '873b46dddcd02ca90c3b22aa6f34b3df0334559b', 'Alberta', 'cynthiablast@hotmail.com', '2024-04-17 03:08:52'),
(20, 'hashed951', 'Antman', 'Cevalier', '63e594789d988b1615a94f265a350981b4090491', 'Quebec', 'antmancevalier@aon.com', '2024-04-17 03:07:48'),
(19, 'hashed753', 'Aaron', 'Johnson', 'bb2867cf3a7f46da026e25b7382df2c28db7d1c1', 'Prince Edward Island', 'aaronjohnson@gmail.com', '2024-04-17 03:06:39'),
(18, 'hashed456', 'Boy', 'Bougli', '9ae777debf994f7dd2441a768f8c5f670c3ecf66', 'Manitoba', 'boybougli@outlook.com', '2024-04-17 03:02:26'),
(17, 'hashed123', 'Bob', 'Barker', 'bb2867cf3a7f46da026e25b7382df2c28db7d1c1', 'Manitoba', 'bobbarker@yahoo.ca', '2024-04-17 02:56:01'),
(24, 'update_security654', 'Security1', 'Update1', '5ed216dd8f1ce41f7e1ede00e214515539268352', 'New Brunswick', 'security1update1@test.com', '2024-04-17 23:34:29');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

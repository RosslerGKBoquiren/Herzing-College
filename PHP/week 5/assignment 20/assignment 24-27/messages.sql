-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 07, 2024 at 12:41 AM
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
-- Table structure for table `messages`
--

DROP TABLE IF EXISTS `messages`;
CREATE TABLE IF NOT EXISTS `messages` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(255) DEFAULT NULL,
  `message` text,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `messages`
--

INSERT INTO `messages` (`id`, `username`, `message`, `created_at`) VALUES
(1, 'LebronJames684', 'Anyone online?', '2024-05-06 23:47:31'),
(2, 'LebronJames684', 'Hello?\r\n', '2024-05-07 00:21:03'),
(3, 'ShaquilleOneal753', 'It\\\'s me BIG DADDY', '2024-05-07 00:30:18'),
(9, 'JaysonTatum651', 'at least he got 5 rings XD', '2024-05-07 00:37:16'),
(8, 'KevinDurant965', 'Nah, Jordan\\\'s cheap', '2024-05-07 00:36:03'),
(6, 'LameloBall458', 'Buy my shoes! 10.0 is out!', '2024-05-07 00:33:05'),
(7, 'MichealJordan852', 'LOL Lamelo. Check -> Jordan IIIIV ', '2024-05-07 00:34:46'),
(10, 'StephenCurry753', 'how much you got Jayson? BIG 0', '2024-05-07 00:38:15'),
(11, 'KobeBryant951', 'Aint here but I listen', '2024-05-07 00:38:49');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

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
) ENGINE=MyISAM AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `username`, `first_name`, `last_name`, `password`, `province`, `email`, `date_joined`, `photo`) VALUES
(36, 'ShaquilleOneal753', 'Shaquille ', 'Oneal', 'bb2867cf3a7f46da026e25b7382df2c28db7d1c1', 'Prince Edward Island', 'shaquilleoneal753@outlook.ca', '2024-05-05 21:17:01', 'uploaded_photos/gaspar-zaldo-_GHkfmjls9Q-unsplash.jpg'),
(37, 'MichealJordan852', 'Michael', 'Jordan', '50a356cdf368b6a2789f7de86401d98ced01fb99', 'Newfoundland & Labra', 'michaeljordan852@yahoo.com', '2024-05-05 21:18:11', 'uploaded_photos/rick-gebhardt-3faX71BaNe0-unsplash.jpg'),
(38, 'DwayneWade324', 'Dwayne', 'Wade', 'd6e9d695ff2dfc4bcb5c4421ba8fab15bbe8b244', 'Nova Scotia', 'dwaynewade324@hotmail.com', '2024-05-05 21:19:21', 'uploaded_photos/jeffery-erhunse-8j4lRnahQY4-unsplash.jpg'),
(39, 'LameloBall458', 'Lamelo', 'Ball', 'f93df4dc6a5edcc0f0774203edaf0f6fa8c48b60', 'Ontario', 'lameloball458@gmail.com', '2024-05-05 21:20:31', 'uploaded_photos/payman-shojaei-OcgkVO3xYz0-unsplash.jpg'),
(40, 'KevinDurant965', 'Kevin', 'Durant', 'e31f2abcba1ab786ae49604cb02ed60234414b72', 'Northwest Territorie', 'kevindurant965@hotmail.com', '2024-05-05 21:21:46', 'uploaded_photos/alexander-mass-DO7jgc2czQ8-unsplash.jpg'),
(41, 'KyrieIrving125', 'Kyrie', 'Irving', 'e595c610a8db90dfdc37c058a6f3d7ee384961d9', 'Alberta', 'kyrieirving125@outlook.com', '2024-05-05 21:25:45', 'uploaded_photos/anna-keibalo-4FwpmQRNOqs-unsplash.jpg'),
(42, 'JaysonTatum651', 'Jayson', 'Tatum', '6e47f78024adb90ac6c51b99d1b6f4186efb4daa', 'Quebec', 'jaysontatum651@gmail.com', '2024-05-05 21:26:36', 'uploaded_photos/pesce-huang-jRhG1fb_cfc-unsplash.jpg'),
(33, 'LebronJames684', 'Lebron', 'James', '65567a49ee04bb2288f9a23a772b34bfa1367db6', 'Yukon', 'lebronjames684@gmail.com', '2024-05-03 01:59:02', 'uploaded_photos/amin-moshrefi--uuCL67QPlQ-unsplash.jpg'),
(34, 'StephenCurry753', 'Stephen', 'Curry', 'bb2867cf3a7f46da026e25b7382df2c28db7d1c1', 'Manitoba', 'stephencurry753@outlook.com', '2024-05-03 02:01:51', 'uploaded_photos/sinitta-leunen-MRDRMHDn7zI-unsplash.jpg'),
(35, 'KobeBryant951', 'Kobe', 'Bryant', '63e594789d988b1615a94f265a350981b4090491', 'British Columbia', 'kobebryant951@gmail.com', '2024-05-03 02:02:57', 'uploaded_photos/tanya-trofymchuk-BUk-2u_VMwQ-unsplash.jpg');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

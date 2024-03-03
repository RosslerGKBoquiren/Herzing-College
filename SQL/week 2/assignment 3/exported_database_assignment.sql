-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: zoo
-- ------------------------------------------------------
-- Server version	8.2.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `animals`
--

DROP TABLE IF EXISTS `animals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `animals` (
  `id` smallint unsigned NOT NULL AUTO_INCREMENT,
  `species` varchar(40) NOT NULL,
  `sex` char(1) DEFAULT NULL,
  `dob` datetime NOT NULL,
  `name` varchar(30) DEFAULT NULL,
  `comments` text,
  `species_id` int NOT NULL,
  `race_id` int DEFAULT NULL,
  `mother_id` smallint unsigned DEFAULT NULL,
  `father_id` smallint unsigned DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_name_id` (`name`,`species_id`),
  KEY `species_id` (`species_id`),
  KEY `race_id_foreign` (`race_id`),
  KEY `index_id` (`id`),
  KEY `mother_id_foreign` (`mother_id`),
  KEY `father_id_foreign` (`father_id`),
  CONSTRAINT `animals_ibfk_1` FOREIGN KEY (`species_id`) REFERENCES `species` (`id`),
  CONSTRAINT `father_id_foreign` FOREIGN KEY (`father_id`) REFERENCES `animals` (`id`),
  CONSTRAINT `mother_id_foreign` FOREIGN KEY (`mother_id`) REFERENCES `animals` (`id`),
  CONSTRAINT `race_id_foreign` FOREIGN KEY (`race_id`) REFERENCES `races` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `animals`
--

LOCK TABLES `animals` WRITE;
/*!40000 ALTER TABLE `animals` DISABLE KEYS */;
INSERT INTO `animals` VALUES (1,'dog','M','2017-04-05 13:43:00','Rox','Bite hard',1,1,18,22),(2,'cat',NULL,'2017-03-24 02:23:00','Roucky',NULL,2,NULL,40,30),(3,'cat','F','2017-09-13 15:02:00','Snory',NULL,2,NULL,41,31),(4,'turtle','F','2016-08-03 05:12:00',NULL,NULL,3,NULL,NULL,NULL),(5,'cat',NULL,'2017-10-03 16:44:00','Choupi','No left hear',2,NULL,NULL,NULL),(6,'turtle','F','2016-06-13 08:17:00','Bobosse','No Shell',3,NULL,NULL,NULL),(7,'dog','F','2015-12-06 05:18:00','Caroline',NULL,1,2,NULL,NULL),(8,'cat','M','2015-09-11 15:38:00','Bagherra',NULL,2,NULL,NULL,NULL),(9,'turtle',NULL,'2017-08-23 05:18:00',NULL,NULL,3,NULL,NULL,NULL),(10,'dog','M','2017-07-21 15:41:00','Bobo',NULL,1,NULL,7,21),(11,'dog','F','2015-02-20 15:45:00','Canaille',NULL,1,NULL,NULL,NULL),(12,'dog','F','2016-05-26 08:54:00','Cali',NULL,1,2,NULL,NULL),(13,'dog','F','2014-04-24 12:54:00','Rouquine',NULL,1,1,NULL,NULL),(14,'dog','F','2016-05-26 08:56:00','Fila',NULL,1,2,NULL,NULL),(15,'dog','F','2015-02-20 15:47:00','Anya',NULL,1,NULL,NULL,NULL),(16,'dog','F','2016-05-26 08:50:00','Louya',NULL,1,NULL,NULL,NULL),(17,'dog','F','2015-03-10 13:45:00','Welva',NULL,1,NULL,NULL,NULL),(18,'dog','F','2014-04-24 12:59:00','Zira',NULL,1,1,NULL,NULL),(19,'dog','F','2016-05-26 09:02:00','Java',NULL,1,2,NULL,NULL),(20,'dog','M','2014-04-24 12:45:00','Balou',NULL,1,1,NULL,NULL),(21,'dog','F','2015-03-10 13:43:00','Pataude',NULL,1,NULL,NULL,NULL),(22,'dog','M','2014-04-24 12:42:00','Bouli',NULL,1,1,NULL,NULL),(24,'dog','M','2014-04-12 05:23:00','Cartouche',NULL,1,NULL,NULL,NULL),(25,'dog','M','2013-05-14 15:50:00','Zambo',NULL,1,1,NULL,NULL),(26,'dog','M','2013-05-14 15:48:00','Samba',NULL,1,1,NULL,NULL),(27,'dog','M','2015-03-10 13:40:00','Moka',NULL,1,NULL,NULL,NULL),(28,'dog','M','2013-05-14 15:40:00','Pilou',NULL,1,1,NULL,NULL),(29,'cat','M','2016-05-14 06:30:00','Fiero',NULL,2,6,NULL,NULL),(30,'cat','M','2014-03-12 12:05:00','Zonko',NULL,2,NULL,NULL,NULL),(31,'cat','M','2015-02-20 15:45:00','Filou',NULL,2,NULL,NULL,NULL),(32,'cat','M','2014-03-12 12:07:00','Farceur',NULL,2,NULL,NULL,NULL),(33,'cat','M','2013-05-19 16:17:00','Caribou',NULL,2,NULL,NULL,NULL),(34,'cat','M','2015-04-20 03:22:00','Capou',NULL,2,NULL,NULL,NULL),(35,'cat','M','2013-05-19 16:56:00','Raccou','no tail',2,NULL,NULL,NULL),(36,'cat','M','2016-05-14 06:42:00','Boucan',NULL,2,6,NULL,NULL),(37,'cat','F','2013-05-19 16:06:00','Callune',NULL,2,NULL,NULL,NULL),(38,'cat','F','2016-05-14 06:45:00','Boule',NULL,2,6,NULL,NULL),(39,'cat','F','2015-04-20 03:26:00','Zara',NULL,2,NULL,NULL,NULL),(40,'cat','F','2014-03-12 12:00:00','Milla',NULL,2,NULL,NULL,NULL),(41,'cat','F','2013-05-19 15:59:00','Feta','Smelly',2,NULL,NULL,NULL),(42,'cat','F','2015-04-20 03:20:00','Bilba','mute',2,NULL,NULL,NULL),(43,'cat','F','2014-03-12 11:54:00','Cracotte',NULL,2,NULL,NULL,NULL),(44,'cat','F','2013-05-19 16:16:00','Cawette',NULL,2,NULL,NULL,NULL),(45,'turtle','F','2014-04-01 18:17:00','Nikkita',NULL,3,NULL,NULL,NULL),(46,'turtle','F','2016-03-24 08:23:00','Tortilla',NULL,3,NULL,NULL,NULL),(47,'turtle','F','2016-03-26 01:24:00','Scroupy',NULL,3,NULL,NULL,NULL),(48,'turtle','F','2013-03-15 14:56:00','Lulla',NULL,3,NULL,NULL,NULL),(49,'turtle','F','2015-03-15 12:02:00','Dana',NULL,3,NULL,NULL,NULL),(50,'turtle','F','2016-05-25 19:57:00','Cheli',NULL,3,NULL,NULL,NULL),(51,'turtle','F','2014-04-01 03:54:00','Chicaca',NULL,3,NULL,NULL,NULL),(52,'turtle','F','2013-03-15 14:26:00','Redbul','Dont sleep',3,NULL,NULL,NULL),(53,'turtle','M','2014-04-02 01:45:00','Spoutnik',NULL,3,NULL,NULL,NULL),(54,'turtle','M','2015-03-16 08:20:00','Bubulle',NULL,3,NULL,NULL,NULL),(55,'turtle','M','2015-03-15 18:45:00','Relou','fat',3,NULL,NULL,NULL),(56,'turtle','M','2016-05-25 18:54:00','Bulbizard',NULL,3,NULL,NULL,NULL),(57,'parrot','M','2014-03-04 19:36:00','Safran',NULL,4,NULL,NULL,NULL),(58,'parrot','M','2015-02-20 02:50:00','Gingko',NULL,4,NULL,NULL,NULL),(59,'perrot','M','2016-03-26 08:28:00','Bavard',NULL,0,NULL,NULL,NULL),(60,'parrot','F','2016-03-26 07:55:00','Parlotte',NULL,4,NULL,NULL,NULL);
/*!40000 ALTER TABLE `animals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `races`
--

DROP TABLE IF EXISTS `races`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `races` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `species_id` int DEFAULT NULL,
  `description` text,
  PRIMARY KEY (`id`),
  KEY `species_id` (`species_id`),
  CONSTRAINT `races_ibfk_1` FOREIGN KEY (`species_id`) REFERENCES `species` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `races`
--

LOCK TABLES `races` WRITE;
/*!40000 ALTER TABLE `races` DISABLE KEYS */;
INSERT INTO `races` VALUES (1,'Affenpinscher',1,'An Affenpinscher generally weighs 6.5 to 13.2 pounds (2.9 to 6.0 kg) and stands 9 to 12 inches (23 to 30 cm) tall at the withers.'),(2,'Boxer',1,'The breed standard dictates that it must be in perfect proportion to the body and above all it must never be too light.[3] The greatest value is to be placed on the muzzle being of correct form and in absolute proportion to the skull.'),(3,'American Bully',1,'According to the American Bully Kennel Club the American bully has a well-defined, powerful appearance with straight, muscular legs. The head is medium-length and broad with a well-defined stop and high-set ears, which may be natural or cropped.'),(4,'American Curl',2,'The American Curl is a breed of cat characterized by its unusual ears, which curl back from the face toward the center of the back of the skull.'),(5,'Abyssinian',2,'The Abyssinian has alert, relatively large pointed ears. The head is broad and moderately wedge-shaped. Its eyes are almond-shaped and colors include gold, green, hazel, or copper. The paws are small and oval. The legs are slender in proportion to the body, with a fine bone structure. The Abyssinian has a fairly long tail, broad at the base and tapering to a point.'),(6,'Bengal',2,'Bengal cats have \"wild-looking\" markings, such as large spots, rosettes, and a light/white belly, and a body structure reminiscent of the leopard cat. A Bengals rosette spots occur only on the back and sides, with stripes elsewhere. The breed typically also features \"mascara\" (horizontal striping alongside the eyes), and foreleg striping.'),(7,'Chausie',2,'Chausies are bred to be medium to large in size, as compared to traditional domestic breeds (Chausie breed standard). Most Chausies are a little smaller than a male Maine Coon, for example, but larger than a Siamese. Adult Chausie males typically weigh 9 to 15 pounds. Adult females are usually 7 to 10 pounds.');
/*!40000 ALTER TABLE `races` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `species`
--

DROP TABLE IF EXISTS `species`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `species` (
  `id` int NOT NULL AUTO_INCREMENT,
  `current_name` varchar(255) DEFAULT NULL,
  `latin_name` varchar(255) DEFAULT NULL,
  `description` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `species`
--

LOCK TABLES `species` WRITE;
/*!40000 ALTER TABLE `species` DISABLE KEYS */;
INSERT INTO `species` VALUES (1,'Dog','Canis familiaris','A domesticated carnivorous mammal that typically has a long snout, and an acute sense of smell.'),(2,'Cat','Felis catus','A small domesticated carnivorous mammal with soft fur, a short snout, and retractile claws.'),(3,'Turtle','Testudo hermanni','A slow-moving reptile, enclosed in a scaly or leathery domed shell into which it can retract its head and thick legs.'),(4,'Parrot','Alipiopstitta xanthops','A bird, often vividly colored, with a short down-curved hooked bill, grasping feet, and a raucous voice, found esp. in the tropics and feeding on fruits and seeds.');
/*!40000 ALTER TABLE `species` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-02 23:33:28

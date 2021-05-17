CREATE DATABASE  IF NOT EXISTS `souvenirshop` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `souvenirshop`;
-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: souvenirshop
-- ------------------------------------------------------
-- Server version	8.0.21

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20210330020758_InitialCreate','5.0.4');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Gấu bông và gối'),(2,'Túi ví'),(3,'Văn phòng phẩm'),(4,'Trang điểm'),(5,'Đồ chơi');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `colors`
--

DROP TABLE IF EXISTS `colors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `colors` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `colors`
--

LOCK TABLES `colors` WRITE;
/*!40000 ALTER TABLE `colors` DISABLE KEYS */;
INSERT INTO `colors` VALUES (1,'Mix'),(2,'Đen'),(3,'Xanh da trời'),(4,'Cam'),(5,'Hồng nhạt'),(6,'Trắng'),(7,'Camel');
/*!40000 ALTER TABLE `colors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Email` text NOT NULL,
  `Password` text NOT NULL,
  `Address` text NOT NULL,
  `Phone` varchar(50) DEFAULT NULL,
  `BirthDate` datetime NOT NULL,
  `IsValid` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'test','test@gmail.com','123456','test','0933750938','2021-05-12 00:00:00','1'),(2,'Trần Thị B','ttb@gmail.com','123456','26 Thoại Ngọc Hầu, Q.Tân Phú','0921231441','2021-05-17 00:00:00','1');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Email` text NOT NULL,
  `Password` text NOT NULL,
  `BirthDate` date NOT NULL,
  `RoleId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Employees_RoleId` (`RoleId`),
  CONSTRAINT `FK_Employees_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (1,'Ong Toàn Khiêm','admin@gmail.com','123456','2000-12-26',1),(3,'Trần Vĩ Văn','tranvivan@gmail.com','abcd@12345','2021-04-01',2),(16,'Nguyễn Văn An','nva@gmail.com','abcd@12345','2021-05-01',4);
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grantpermissions`
--

DROP TABLE IF EXISTS `grantpermissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grantpermissions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `PermissionId` int NOT NULL,
  `RoleId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_GrantPermissions_PermissionId` (`PermissionId`),
  KEY `IX_GrantPermissions_RoleId` (`RoleId`),
  CONSTRAINT `FK_GrantPermissions_Permissions_PermissionId` FOREIGN KEY (`PermissionId`) REFERENCES `permissions` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_GrantPermissions_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grantpermissions`
--

LOCK TABLES `grantpermissions` WRITE;
/*!40000 ALTER TABLE `grantpermissions` DISABLE KEYS */;
INSERT INTO `grantpermissions` VALUES (1,1,1),(2,2,1),(3,3,1),(10,4,1),(11,5,1),(12,5,2),(13,2,4),(14,4,4),(15,5,4);
/*!40000 ALTER TABLE `grantpermissions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `importingoders`
--

DROP TABLE IF EXISTS `importingoders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `importingoders` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `InvoiceDate` datetime NOT NULL,
  `Total` int NOT NULL,
  `DeliveryDate` datetime NOT NULL,
  `Status` text NOT NULL,
  `SupplierId` int NOT NULL,
  `EmployeeId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ImportingOders_EmployeeId` (`EmployeeId`),
  KEY `IX_ImportingOders_SupplierId` (`SupplierId`),
  CONSTRAINT `FK_ImportingOders_Employees_EmployeeId` FOREIGN KEY (`EmployeeId`) REFERENCES `employees` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ImportingOders_Suppliers_SupplierId` FOREIGN KEY (`SupplierId`) REFERENCES `suppliers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `importingoders`
--

LOCK TABLES `importingoders` WRITE;
/*!40000 ALTER TABLE `importingoders` DISABLE KEYS */;
/*!40000 ALTER TABLE `importingoders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `importingtransactions`
--

DROP TABLE IF EXISTS `importingtransactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `importingtransactions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Quantity` int NOT NULL,
  `Price` int NOT NULL,
  `ProductDetailId` int NOT NULL,
  `ImportingOrderId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ImportingTransactions_ImportingOrderId` (`ImportingOrderId`),
  KEY `IX_ImportingTransactions_ProductDetailId` (`ProductDetailId`),
  CONSTRAINT `FK_ImportingTransactions_ImportingOders_ImportingOrderId` FOREIGN KEY (`ImportingOrderId`) REFERENCES `importingoders` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ImportingTransactions_ProductDetails_ProductDetailId` FOREIGN KEY (`ProductDetailId`) REFERENCES `productdetails` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `importingtransactions`
--

LOCK TABLES `importingtransactions` WRITE;
/*!40000 ALTER TABLE `importingtransactions` DISABLE KEYS */;
/*!40000 ALTER TABLE `importingtransactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permissions`
--

DROP TABLE IF EXISTS `permissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `permissions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Code` text NOT NULL,
  `Description` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permissions`
--

LOCK TABLES `permissions` WRITE;
/*!40000 ALTER TABLE `permissions` DISABLE KEYS */;
INSERT INTO `permissions` VALUES (1,'PRODUCT_MANAGEMENT','Quản lý hàng hoá'),(2,'CUSTOMER_MANAGEMENT','Quản lý khách hàng'),(3,'EMPLOYEE_MANAGEMENT','Quản lý nhân viên'),(4,'SUPPLIER_MANAGEMENT','Quản lý nhà cung cấp'),(5,'TRANSACTION_MANAGEMENT','Quản lý hoạt động giao dịch');
/*!40000 ALTER TABLE `permissions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productdetails`
--

DROP TABLE IF EXISTS `productdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productdetails` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Quantity` int NOT NULL,
  `SellingPrice` int NOT NULL,
  `ImportingPrice` int NOT NULL,
  `ImageUrl` varchar(250) DEFAULT NULL,
  `ColorId` int NOT NULL,
  `SizeId` int NOT NULL,
  `ProductId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ProductDetails_ColorId` (`ColorId`),
  KEY `IX_ProductDetails_ProductId` (`ProductId`),
  KEY `IX_ProductDetails_SizeId` (`SizeId`),
  CONSTRAINT `FK_ProductDetails_Colors_ColorId` FOREIGN KEY (`ColorId`) REFERENCES `colors` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProductDetails_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProductDetails_Sizes_SizeId` FOREIGN KEY (`SizeId`) REFERENCES `sizes` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productdetails`
--

LOCK TABLES `productdetails` WRITE;
/*!40000 ALTER TABLE `productdetails` DISABLE KEYS */;
INSERT INTO `productdetails` VALUES (1,'Gấu bông MS Mèo con cảm xúc đổi mặt 15cm Đen',3,70000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210515/21050110_bl.jpg',2,1,2),(3,'Gấu bông MS Mèo con cảm xúc đổi mặt 15cm Xanh',3,70000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210515/21050110_bu.jpg',3,1,2),(4,'Gấu bông MS Mèo con cảm xúc đổi mặt 15cm Cam',4,70000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210515/21050110_or.jpg',4,1,2),(5,'Gấu bông MS Rùa con cảm xúc đổi mặt 15cm',10,70000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210514/21051078_BU_thumb_450x450.JPG',3,1,3),(6,'Gấu bông MS Among Us cảm xúc đổi mặt 15cm',10,70000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210514/21051077_XX_thumb_450x450.JPG',1,1,4),(7,'Gấu bông MS Llama má hồng cute 23cm - Hồng nhạt',5,135000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210514/21030203_hoc.jpg',5,1,5),(8,'Gấu bông MS Llama má hồng cute 23cm - Trắng',5,135000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210514/21030203_wh.jpg',6,1,5),(9,'Gấu bông MS Unicorn Tuần lộc sleepy lông xoắn',10,130000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210514/21040329_CM_1000x1000.JPG',7,1,6),(10,'Gấu bông chữ U MZ Black Cat - Mix',10,140000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210515/21055001_XX_1000x1000.JPG',1,1,7),(11,'Gấu bông chữ U Cún corgi hoa nhỏ nằm - Camel',10,185000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210417/21042065_MT_1000x897.JPG',7,1,8),(12,'Gấu bông chữ U Cá sấu má hồng mắt nổi - Mix',10,160000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210514/21042064_GN_1000x1000.JPG',1,1,9),(13,'Gấu bông chữ U ruột cao su Cún mắt hí - Mix',10,160000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210508/21040095_BR_1000x1000.JPG',1,1,10),(14,'Gấu bông tựa lưng Alpaca đeo nơ 30x50 - Hồng nhạt',10,260000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210417/21042067_hoc_thumb_450x450.JPG',5,1,11),(15,'Đệm gấu bông Họa tiết lông mèo 40cm',10,260000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210417/21040126_or.jpg',1,1,12),(16,'Đệm gấu bông Sumikko Neko and Penguin 45cm',10,160000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210417/21040091_LM_1000x1000.JPG',1,1,13),(17,'Đệm gấu bông Cún Shiba gà vàng penguin 45cm - Xanh',3,160000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210417/21040090_lb.jpg',3,1,14),(18,'Đệm gấu bông Cún Shiba gà vàng penguin 45cm - Came',7,160000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210417/21040090_br.jpg',7,1,14),(19,'Đệm gấu bông Mèo áo hoa 35cm',10,170000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210407/21040007_PE_1000x1000.JPG',1,1,15),(20,'Túi đeo chéo da Cute motifs quai phối lụa 7x16x21 ',5,280000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210508/21041287_bl.jpg',2,1,16),(21,'Túi đeo chéo da Cute motifs quai phối lụa 7x16x21 ',5,280000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210508/21041287_wh.jpg',1,1,16),(22,'Balo gấu bông Alpaca cute màu sắc 40cm - Mix',10,320000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210508/21040092_XX_1000x1000.JPG',1,1,17),(23,'Ví da gập ngắn Thỏ Bunny cute face nền kẻ ô 9x11',10,130000,50000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210517/21041241_PE_1000x1000.JPG',1,1,18),(24,'Túi ví đa năng Animal cute face 8x10 - Mix',10,60000,30000,'https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210517/21040336_XX_1000x1000.JPG',1,1,19);
/*!40000 ALTER TABLE `productdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Quantity` int NOT NULL,
  `Description` text NOT NULL,
  `ImageUrl` varchar(225) DEFAULT NULL,
  `SellingPrice` int NOT NULL,
  `SubCategoryId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Products_SubCategoryId` (`SubCategoryId`),
  CONSTRAINT `FK_Products_SubCategories_SubCategoryId` FOREIGN KEY (`SubCategoryId`) REFERENCES `subcategories` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (2,'Gấu bông MS Mèo con cảm xúc đổi mặt 15cm',10,'Gấu bông MS Mèo con cảm xúc đổi mặt 15cm','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210515/21050110_thumb_450x450.JPG',70000,1),(3,'Gấu bông MS Rùa con cảm xúc đổi mặt 15cm',10,'Gấu bông MS Rùa con cảm xúc đổi mặt 15cm','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210514/21051078_BU_thumb_450x450.JPG',70000,1),(4,'Gấu bông MS Among Us cảm xúc đổi mặt 15cm',10,'Gấu bông MS Among Us cảm xúc đổi mặt 15cm','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210514/21051077_XX_thumb_450x450.JPG',70000,1),(5,'Gấu bông MS Llama má hồng cute 23cm',10,'Gấu bông MS Llama má hồng cute 23cm','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210514/21030203_thumb_450x450.JPG',135000,1),(6,'Gấu bông MS Unicorn Tuần lộc sleepy lông xoắn 23cm',12,'Gấu bông MS Unicorn Tuần lộc sleepy lông xoắn 23cm','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210514/21040329_CM_thumb_450x450.JPG',130000,1),(7,'Gấu bông chữ U MZ Black Cat',10,'Gấu bông chữ U MZ Black Cat','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210515/21055001_XX_thumb_450x450.JPG',140000,2),(8,'Gấu bông chữ U Cún corgi hoa nhỏ nằm',10,'Gấu bông chữ U Cún corgi hoa nhỏ nằm','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210417/21042065_MT_thumb_450x403.JPG',185000,2),(9,'Gấu bông chữ U Cá sấu má hồng mắt nổi',10,'Gấu bông chữ U Cá sấu má hồng mắt nổi','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210514/21042064_GN_thumb_450x450.JPG',160000,2),(10,'Gấu bông chữ U ruột cao su Cún mắt hí',10,'Gấu bông chữ U ruột cao su Cún mắt hí','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210508/21040095_BR_thumb_450x450.JPG',160000,2),(11,'Gấu bông tựa lưng Alpaca đeo nơ 30x50',10,'Gấu bông tựa lưng Alpaca đeo nơ 30x50','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210417/21042067_hoc_thumb_450x450.JPG',260000,3),(12,'Đệm gấu bông Họa tiết lông mèo 40cm',10,'Đệm gấu bông Họa tiết lông mèo 40cm','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210417/21040126_OR_thumb_450x450.JPG',260000,3),(13,'Đệm gấu bông Sumikko Neko and Penguin 45cm',10,'Đệm gấu bông Sumikko Neko and Penguin 45cm','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210417/21040091_LM_thumb_450x450.JPG',160000,3),(14,'Đệm gấu bông Cún Shiba gà vàng penguin 45cm',10,'Đệm gấu bông Cún Shiba gà vàng penguin 45cm','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210417/21040090_BR_thumb_450x450.JPG',160000,3),(15,'Đệm gấu bông Mèo áo hoa 35cm',10,'Đệm gấu bông Mèo áo hoa 35cm','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210407/21040007_PE_thumb_450x450.JPG',170000,3),(16,'Túi đeo chéo da Cute motifs quai phối lụa 7x16x21',10,'Túi đeo chéo da Cute motifs quai phối lụa 7x16x21','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210508/21041287_thumb_450x450.JPG',280000,4),(17,'Balo gấu bông Alpaca cute màu sắc 40cm',10,'Balo gấu bông Alpaca cute màu sắc 40cm','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210508/21040092_XX_thumb_450x450.JPG',320000,5),(18,'Ví da gập ngắn Thỏ Bunny cute face nền kẻ ô 9x11',10,'Ví da gập ngắn Thỏ Bunny cute face nền kẻ ô 9x11','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210517/21041241_PE_thumb_450x450.JPG',130000,6),(19,'Túi ví đa năng Animal cute face 8x10',10,'Túi ví đa năng Animal cute face 8x10','https://storage.googleapis.com/cdn.nhanh.vn/store/7534/ps/20210517/21040336_XX_thumb_450x450.JPG',60000,7);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Admin'),(2,'Nhân viên trực page'),(4,'Nhân viên marketing');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sellingorders`
--

DROP TABLE IF EXISTS `sellingorders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sellingorders` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `InvoiceDate` datetime NOT NULL,
  `Total` int NOT NULL,
  `Address` varchar(50) NOT NULL,
  `DeliveryDate` datetime DEFAULT NULL,
  `ReceivePerson` varchar(50) NOT NULL,
  `Status` text NOT NULL,
  `CustomerId` int NOT NULL,
  `PaymentIndentId` varchar(225) DEFAULT NULL,
  `ClientSecret` varchar(225) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_SellingOrders_CustomerId` (`CustomerId`),
  CONSTRAINT `FK_SellingOrders_Customers_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sellingorders`
--

LOCK TABLES `sellingorders` WRITE;
/*!40000 ALTER TABLE `sellingorders` DISABLE KEYS */;
INSERT INTO `sellingorders` VALUES (19,'2021-01-17 00:00:00',140000,'test','2021-01-17 00:00:00','test','Đã hoàn thành',1,'pi_1IrzwFKa2ZJyHG3E6Pmy995i','pi_1IrzwFKa2ZJyHG3E6Pmy995i_secret_6o44gOMTzeG3QP5teOHqqUtVi'),(20,'2021-02-15 00:00:00',210000,'test','2021-02-15 00:00:00','test','Đã hoàn thành',1,'pi_1Is0FGKa2ZJyHG3EEFHGuSMg','pi_1Is0FGKa2ZJyHG3EEFHGuSMg_secret_fXbBalIuTSvFMvcBBRsUA5l84'),(21,'2021-02-17 00:00:00',360000,'test','2021-02-17 00:00:00','test','Đã hoàn thành',1,'pi_1Is0FGKa2ZJyHG3EEFHGuSMg','pi_1Is0FGKa2ZJyHG3EEFHGuSMg_secret_fXbBalIuTSvFMvcBBRsUA5l84'),(22,'2021-03-22 00:00:00',1200000,'test','2021-03-22 00:00:00','test','Đã hoàn thành',1,'pi_1Is0FGKa2ZJyHG3EEFHGuSMg','pi_1Is0FGKa2ZJyHG3EEFHGuSMg_secret_fXbBalIuTSvFMvcBBRsUA5l84'),(23,'2021-04-26 00:00:00',500000,'test','2021-04-26 00:00:00','test','Đã hoàn thành',1,'pi_1Is0FGKa2ZJyHG3EEFHGuSMg','pi_1Is0FGKa2ZJyHG3EEFHGuSMg_secret_fXbBalIuTSvFMvcBBRsUA5l84'),(24,'2021-05-21 00:00:00',60000,'test','2021-05-21 00:00:00','test','Đã hoàn thành',1,'pi_1Is0FGKa2ZJyHG3EEFHGuSMg','pi_1Is0FGKa2ZJyHG3EEFHGuSMg_secret_fXbBalIuTSvFMvcBBRsUA5l84'),(25,'2021-05-22 00:00:00',100000,'test','2021-05-22 00:00:00','test','Đã hoàn thành',1,'pi_1Is0FGKa2ZJyHG3EEFHGuSMg','pi_1Is0FGKa2ZJyHG3EEFHGuSMg_secret_fXbBalIuTSvFMvcBBRsUA5l84');
/*!40000 ALTER TABLE `sellingorders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sellingtransactions`
--

DROP TABLE IF EXISTS `sellingtransactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sellingtransactions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Quantity` int NOT NULL,
  `Price` int NOT NULL,
  `ProductDetailId` int NOT NULL,
  `SellingOrderId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_SellingTransactions_ProductDetailId` (`ProductDetailId`),
  KEY `IX_SellingTransactions_SellingOrderId` (`SellingOrderId`),
  CONSTRAINT `FK_SellingTransactions_ProductDetails_ProductDetailId` FOREIGN KEY (`ProductDetailId`) REFERENCES `productdetails` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_SellingTransactions_SellingOrders_SellingOrderId` FOREIGN KEY (`SellingOrderId`) REFERENCES `sellingorders` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sellingtransactions`
--

LOCK TABLES `sellingtransactions` WRITE;
/*!40000 ALTER TABLE `sellingtransactions` DISABLE KEYS */;
INSERT INTO `sellingtransactions` VALUES (32,1,70000,1,19),(33,1,70000,3,19),(35,2,210000,6,20),(36,1,60000,1,21),(37,1,300000,3,21),(38,1,1200000,1,22),(39,1,500000,3,23),(40,1,60000,1,24),(41,1,100000,3,25);
/*!40000 ALTER TABLE `sellingtransactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sizes`
--

DROP TABLE IF EXISTS `sizes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sizes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sizes`
--

LOCK TABLES `sizes` WRITE;
/*!40000 ALTER TABLE `sizes` DISABLE KEYS */;
INSERT INTO `sizes` VALUES (1,'Mix'),(4,'30x30'),(5,'Mix');
/*!40000 ALTER TABLE `sizes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subcategories`
--

DROP TABLE IF EXISTS `subcategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subcategories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `CategoryId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_SubCategories_CategoryId` (`CategoryId`),
  CONSTRAINT `FK_SubCategories_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subcategories`
--

LOCK TABLES `subcategories` WRITE;
/*!40000 ALTER TABLE `subcategories` DISABLE KEYS */;
INSERT INTO `subcategories` VALUES (1,'Gấu bông cute',1),(2,'Gối chữ U',1),(3,'Gấu bông khác',1),(4,'Túi đeo',2),(5,'Balo',2),(6,'Ví',2),(7,'Túi đa năng',2),(8,'Sổ vở',3),(9,'Móc khoá',3),(10,'Quạt',3),(11,'Bao túi quà, hộp quà',3),(12,'Gương lược',4),(13,'Đựng mỹ phẩm',4),(14,'Dụng cụ trang điểm',4),(15,'Đồ chơi',5),(16,'Đồ thú cưng',5);
/*!40000 ALTER TABLE `subcategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suppliers` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Address` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,'Test','địa chỉ test');
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-17 18:37:39

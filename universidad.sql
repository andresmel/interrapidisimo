-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.30 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para universidad
CREATE DATABASE IF NOT EXISTS `universidad` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `universidad`;

-- Volcando estructura para tabla universidad.clases
CREATE TABLE IF NOT EXISTS `clases` (
  `id_clase` int NOT NULL AUTO_INCREMENT,
  `id_estudiante` int DEFAULT NULL,
  `id_materias_profesores` int DEFAULT NULL,
  PRIMARY KEY (`id_clase`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla universidad.clases: ~10 rows (aproximadamente)
INSERT INTO `clases` (`id_clase`, `id_estudiante`, `id_materias_profesores`) VALUES
	(1, 3, 1),
	(2, 3, 3),
	(3, 3, 5),
	(4, 1, 2),
	(5, 1, 10),
	(6, 1, 4),
	(7, 2, 6),
	(8, 2, 1),
	(9, 4, 1),
	(10, 5, 5),
	(11, 5, 7);

-- Volcando estructura para tabla universidad.estudiantes
CREATE TABLE IF NOT EXISTS `estudiantes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) DEFAULT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla universidad.estudiantes: ~5 rows (aproximadamente)
INSERT INTO `estudiantes` (`id`, `nombre`, `email`, `password`) VALUES
	(1, 'andres melo', 'andres@uniminuto.edu.co', '$2a$11$xZ2rXWyQjOiXWqA7RavKPO4QUlzzI7lDP6WUyocJRSIpT08u9XC86'),
	(2, 'carlos medina', 'carlos@uniminuto.edu.co', '$2a$11$jZ4edK/SauHz4oWeO8jBKuUhJVbcbIOmeHEKnHT3pZG.Qv94l7Ey2'),
	(3, 'maria escandon', 'maria@uniminuto.edu.co', '$2a$11$8GgjVFD9He0EoyorqEdOiOc5AIuQKWgxw10/2DZj/UQuXwN0Wv3gm'),
	(4, 'laura mendez', 'laura@uniminuto.edu.co', '$2a$11$UbaUSMFWXhOC160LFjiRbukME4dkYUXJBbSUt20v8Mbriq1l79b3e'),
	(5, 'raul martinez', 'raul@uniminuto.edu.co', '$2a$11$NULJU7Q8njcc8wBLn1TQUeQGkJz1HRoWfPVJimiUZmtUZcX7Efxuu');

-- Volcando estructura para tabla universidad.materias
CREATE TABLE IF NOT EXISTS `materias` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) DEFAULT NULL,
  `creditos` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla universidad.materias: ~10 rows (aproximadamente)
INSERT INTO `materias` (`id`, `nombre`, `creditos`) VALUES
	(1, 'Matemáticas', 3),
	(2, 'Física', 3),
	(3, 'Química', 3),
	(4, 'Biología', 3),
	(5, 'Historia', 3),
	(6, 'Literatura', 3),
	(7, 'Inglés', 3),
	(8, 'Informática', 3),
	(9, 'Economía', 3),
	(10, 'Filosofía', 3);

-- Volcando estructura para tabla universidad.materias_profesores
CREATE TABLE IF NOT EXISTS `materias_profesores` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_profesor` int DEFAULT NULL,
  `id_materia` int DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla universidad.materias_profesores: ~10 rows (aproximadamente)
INSERT INTO `materias_profesores` (`id`, `id_profesor`, `id_materia`) VALUES
	(1, 1, 1),
	(2, 1, 2),
	(3, 2, 3),
	(4, 2, 4),
	(5, 3, 5),
	(6, 3, 6),
	(7, 4, 7),
	(8, 4, 8),
	(9, 5, 9),
	(10, 5, 10);

-- Volcando estructura para tabla universidad.profesores
CREATE TABLE IF NOT EXISTS `profesores` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla universidad.profesores: ~5 rows (aproximadamente)
INSERT INTO `profesores` (`id`, `nombre`) VALUES
	(1, 'Juan Pérez'),
	(2, 'María Gómez'),
	(3, 'Carlos Ruiz'),
	(4, 'Ana Martínez'),
	(5, 'Luis Torres');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

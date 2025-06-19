-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 19-06-2025 a las 23:40:28
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.1.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `tienda_poo2`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminar_cliente` (IN `p_id_cliente` INT)   BEGIN
    DELETE FROM clientes WHERE id_cliente = p_id_cliente;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminar_producto` (IN `p_id_producto` INT)   BEGIN
    DELETE FROM productos WHERE id_producto = p_id_producto;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminar_venta` (IN `p_id_venta` INT)   BEGIN
    DELETE FROM ventas WHERE id_venta = p_id_venta;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_cliente` (IN `p_nombre` VARCHAR(100), IN `p_correo` VARCHAR(100), IN `p_telefono` VARCHAR(20), IN `p_direccion` VARCHAR(200))   BEGIN
    INSERT INTO clientes (nombre, correo, telefono, direccion)
    VALUES (p_nombre, p_correo, p_telefono, p_direccion);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_producto` (IN `p_nombre_producto` VARCHAR(100), IN `p_descripcion` TEXT, IN `p_precio` DECIMAL(10,2), IN `p_stock` INT)   BEGIN
    INSERT INTO productos (nombre_producto, descripcion, precio, stock)
    VALUES (p_nombre_producto, p_descripcion, p_precio, p_stock);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertar_venta` (IN `p_id_cliente` INT, IN `p_id_producto` INT, IN `p_cantidad` INT)   BEGIN
    INSERT INTO ventas (id_cliente, id_producto, cantidad)
    VALUES (p_id_cliente, p_id_producto, p_cantidad);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `seleccionar_clientes` ()   BEGIN
    SELECT * FROM clientes;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `seleccionar_productos` ()   BEGIN
    SELECT * FROM productos;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `seleccionar_ventas` ()   BEGIN
    SELECT v.id_venta, c.nombre AS cliente, p.nombre_producto, v.cantidad, v.fecha_venta
    FROM ventas v
    INNER JOIN clientes c ON v.id_cliente = c.id_cliente
    INNER JOIN productos p ON v.id_producto = p.id_producto;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `id_cliente` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `correo` varchar(100) NOT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `direccion` varchar(200) DEFAULT NULL,
  `fecha_registro` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`id_cliente`, `nombre`, `correo`, `telefono`, `direccion`, `fecha_registro`) VALUES
(1, 'Edwin Barrazueta', 'epbarrazueta@hotmail.com', '0963369909', 'Quito', '2025-06-19 21:03:49'),
(2, 'Renata Salazar', 'rasalazar@hotmail.com', '0987789559', 'Quito', '2025-06-19 21:04:18');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `id_producto` int(11) NOT NULL,
  `nombre_producto` varchar(100) NOT NULL,
  `descripcion` text DEFAULT NULL,
  `precio` decimal(10,2) NOT NULL,
  `stock` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`id_producto`, `nombre_producto`, `descripcion`, `precio`, `stock`) VALUES
(1, 'Librero Esquinero', 'Librero esquinero de color negro', 20000.00, 25),
(2, 'Escritorio Elevadizo', 'Escritorio con altura ajustable', 60000.00, 50),
(3, 'Repisa Flotante', 'Repisas flotantes para interiores', 2500.00, 100);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas`
--

CREATE TABLE `ventas` (
  `id_venta` int(11) NOT NULL,
  `id_cliente` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL DEFAULT 1,
  `fecha_venta` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `ventas`
--

INSERT INTO `ventas` (`id_venta`, `id_cliente`, `id_producto`, `cantidad`, `fecha_venta`) VALUES
(1, 1, 1, 1, '2025-06-19 21:09:44'),
(2, 2, 2, 1, '2025-06-19 21:09:57');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`id_cliente`),
  ADD UNIQUE KEY `correo` (`correo`);

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id_producto`);

--
-- Indices de la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD PRIMARY KEY (`id_venta`),
  ADD KEY `id_cliente` (`id_cliente`),
  ADD KEY `id_producto` (`id_producto`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `clientes`
--
ALTER TABLE `clientes`
  MODIFY `id_cliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `id_producto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `ventas`
--
ALTER TABLE `ventas`
  MODIFY `id_venta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD CONSTRAINT `ventas_ibfk_1` FOREIGN KEY (`id_cliente`) REFERENCES `clientes` (`id_cliente`),
  ADD CONSTRAINT `ventas_ibfk_2` FOREIGN KEY (`id_producto`) REFERENCES `productos` (`id_producto`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

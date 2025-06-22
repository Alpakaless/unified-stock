-- phpMyAdmin SQL Dump
-- version 4.0.4.2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jun 11, 2025 at 10:41 PM
-- Server version: 5.6.13
-- PHP Version: 5.4.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `unified-stock`
--
CREATE DATABASE IF NOT EXISTS `unified-stock` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `unified-stock`;

-- --------------------------------------------------------

--
-- Table structure for table `fornecedores`
--

CREATE TABLE IF NOT EXISTS `fornecedores` (
  `CNPJ` varchar(14) NOT NULL DEFAULT '0',
  `Nome` varchar(50) NOT NULL,
  `Telefone` varchar(10) NOT NULL,
  `Email` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CNPJ`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fornecedores`
--

INSERT INTO `fornecedores` (`CNPJ`, `Nome`, `Telefone`, `Email`) VALUES
('00222888123467', 'Humberto', '123123123', 'Humberto@fatec'),
('00623904000173', 'Apple', '1234512345', 'Apple@brasil');

-- --------------------------------------------------------

--
-- Table structure for table `funcionarios`
--

CREATE TABLE IF NOT EXISTS `funcionarios` (
  `CPF` varchar(11) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Senha` varchar(20) NOT NULL,
  `Tipo` varchar(5) NOT NULL,
  PRIMARY KEY (`CPF`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `funcionarios`
--

INSERT INTO `funcionarios` (`CPF`, `Nome`, `Email`, `Senha`, `Tipo`) VALUES
('11111111122', 'Gustavo', 'gustavo@fatec', '123', 'ADM'),
('12121212133', 'Moquidésia', 'moquidésia@fatec', '123', 'FUNC'),
('12312312312', 'Rennan', 'Rennan@fatec', '123', 'FUNC'),
('22222222211', 'Bruno', 'bruno@fatec', '1234', 'ADM'),
('77777777777', 'Bundei', 'Bundei@lol', '727', 'ADM');

-- --------------------------------------------------------

--
-- Table structure for table `produtos`
--

CREATE TABLE IF NOT EXISTS `produtos` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(50) NOT NULL,
  `Descricao` varchar(50) NOT NULL,
  `Preco` decimal(10,2) NOT NULL,
  `Quantidade` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `produtos`
--

INSERT INTO `produtos` (`ID`, `Nome`, `Descricao`, `Preco`, `Quantidade`) VALUES
(1, 'Celular', '6GB', '2500.00', 3),
(2, 'Danone Diferente', 'Bem diferente', '15.00', 5),
(3, 'Capinha', 'Azul', '20.00', 32);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
